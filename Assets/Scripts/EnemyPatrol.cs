using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    public float startSpeed;
    public float chaseSpeed;

    private Vector3 pointApos;
    private Vector3 pointBpos;

    public GameObject player;

    public Collider2D territoryCol;

    public float knockbackPower = 100;
    public float knockbackDuration = 1;

    public SpriteRenderer zombieRend;
    int zombieOrd;
    [HideInInspector]
    public bool chasing = false;

    void Start()
    {
        pointApos = pointA.transform.position;
        pointBpos = pointB.transform.position;
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        startSpeed = speed;
        //anim.SetBool("isRunning", true);

        zombieRend = this.gameObject.GetComponent<SpriteRenderer>();
        zombieOrd = zombieRend.sortingOrder;

    }

    void Update()
    {
        if(chasing == true)
        {
            zombieRend.sortingOrder = player.GetComponent<SpriteRenderer>().sortingOrder;
        }
        else
        {
            zombieRend.sortingOrder = zombieOrd;
        }


        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint.position == pointB.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);
        }

        if (currentPoint.position == pointA.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);
        }


        if (Vector2.Distance(transform.position, currentPoint.position) == 0f && currentPoint == pointB.transform)
        {
            //Flip();
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) == 0f && currentPoint == pointA.transform)
        {
           // Flip();
            currentPoint = pointB.transform;
        }

        if(transform.position.y > currentPoint.position.y && transform.position.x == currentPoint.position.x)
        {
            anim.SetBool("Front", true);
        }
        else
        {
            anim.SetBool("Front", false);
        }

        if (transform.position.y < currentPoint.position.y && transform.position.x == currentPoint.position.x)
        {
            anim.SetBool("Back", true);
        }
        else
        {
            anim.SetBool("Back", false);
        }

        if (transform.position.y == currentPoint.position.y && transform.position.x != currentPoint.position.x && transform.position.x < currentPoint.position.x)
        {
            anim.SetBool("Side", true);
        }
        else
        {
            anim.SetBool("Side", false);
        }

        if (transform.position.y == currentPoint.position.y && transform.position.x != currentPoint.position.x && transform.position.x > currentPoint.position.x)
        {
            anim.SetBool("Side", true);
            Flip();
        }
        else
        {
            anim.SetBool("Side", false);
        }

        if (transform.position.y < currentPoint.position.y && transform.position.x != currentPoint.position.x && transform.position.x < currentPoint.position.x)
        {
            anim.SetBool("SideUp", true);

        }
        else
        {
            anim.SetBool("SideUp", false);

        }

        if (transform.position.y > currentPoint.position.y && transform.position.x != currentPoint.position.x && transform.position.x < currentPoint.position.x)
        {
            anim.SetBool("SideDown", true);
        }
        else
        {
            anim.SetBool("SideDown", false);
        }


        if (transform.position.y < currentPoint.position.y && transform.position.x != currentPoint.position.x && transform.position.x > currentPoint.position.x)
        {
            anim.SetBool("SideUpLeft", true);

        }
        else
        {
            anim.SetBool("SideUpLeft", false);

        }

        if (transform.position.y > currentPoint.position.y && transform.position.x != currentPoint.position.x && transform.position.x > currentPoint.position.x)
        {
            anim.SetBool("SideDownLeft", true);
        }
        else
        {
            anim.SetBool("SideDownLeft", false);
        }
    }




    public void OnTriggerEnter2D(Collider2D chase)
    {
        if(chase.gameObject.tag == "Player")
        {
           // Debug.Log("Enter");

            StartCoroutine(PlayerPos());
            speed = speed + chaseSpeed;
            chasing = true;
        }

        if (chase.gameObject.tag == "CandyBite")
        {
           
            //Debug.Log("Bite");
            pointA.transform.position = chase.gameObject.transform.position;
            pointB.transform.position = chase.gameObject.transform.position;
            currentPoint.position = chase.gameObject.transform.position;
            // currentPoint.position = chase.gameObject.transform.position;
            //Debug.Log(chase.gameObject.transform.position);
            speed = speed + chaseSpeed;
            StopAllCoroutines();
            territoryCol.enabled = false;

            if (transform.position == chase.gameObject.transform.position)
            {
                speed = 0f;
                chaseSpeed = 0f;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D chase)
    {

        if (chase.gameObject.tag == "Player")
        {
            // Debug.Log("Exit");
            StopAllCoroutines();
            speed = startSpeed;
            //StopCoroutine(PlayerPos());

            if (currentPoint == pointA.transform)
            {
                currentPoint.position = pointApos;
            }

            if (currentPoint == pointB.transform)
            {
                currentPoint.position = pointBpos;
            }

            currentPoint = pointA.transform;
            chasing = false;
            territoryCol.enabled = true;
        }

        if(chase.gameObject.tag == "CandyBite")
        {
            //StartCoroutine(Territory(2, true));

            if (currentPoint == pointA.transform)
            {
                currentPoint.position = pointApos;
            }

            if (currentPoint == pointB.transform)
            {
                currentPoint.position = pointBpos;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(Knockback.instance.KnockbackPl(knockbackDuration, knockbackPower, this.transform));
            speed = startSpeed;

            StopAllCoroutines();
           
           // StartCoroutine(Territory(0, false));

            if (currentPoint == pointA.transform)
            {
                currentPoint.position = pointApos;
            }

            if (currentPoint == pointB.transform)
            {
                currentPoint.position = pointBpos;
            }

           // StartCoroutine(Territory(3, true));
        }
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.1f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.1f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }


    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public IEnumerator PlayerPos()
    {
        yield return new WaitForEndOfFrame();
       // Debug.Log("Frame");
        currentPoint.position = player.transform.position;
        StartCoroutine(PlayerPos());
    }

    public IEnumerator Territory(float sek, bool isIt)
    {
        yield return new WaitForSeconds(sek);
        territoryCol.enabled = isIt;
    }



}
