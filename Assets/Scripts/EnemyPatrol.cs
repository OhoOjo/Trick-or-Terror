using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public List<GameObject> points = new List<GameObject>();

    private Rigidbody2D rb;
    private Animator anim;
    public Transform currentPoint;
    public float speed;
    public float startSpeed;
    public float chaseSpeed;

    private Vector2 point;
    private int i;

    public GameObject player;

    public Collider2D territoryCol;

    public SpriteRenderer zombieRend;
    int zombieOrd;
    [HideInInspector]
    public bool chasing = false;

    private Vector3 pointZero;

    private GameObject Lose;

    void Awake()
    {

        i = 0;

        Lose = GameObject.FindWithTag("LOSE");
        if(Lose == null)
        {
            return;
        }
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = points[0].transform;
        MoveToPoint();
        startSpeed = speed;
        //anim.SetBool("isRunning", true);
       
        zombieRend = this.gameObject.GetComponent<SpriteRenderer>();
        //zombieOrd = zombieRend.sortingOrder;

    }

    void Start()
    {
        pointZero = points[0].transform.position;
        MoveToPoint();
    }

    void MoveToPoint()
    {
        currentPoint = points[i].transform;
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);

        if (currentPoint.position == points[i].transform.position)
        {
            if(transform.position == currentPoint.position)
            {
                i++;
                if (i >= points.Count)
                {
                    i = 0;
                }
                currentPoint = points[i].transform;
               // MoveToPoint();
            }
        }

    }

    void Update()
    {

        if(player == null | anim == null | rb == null | currentPoint == null)
        {
            player = GameObject.FindWithTag("Player");
            rb = GetComponent<Rigidbody2D>();
            currentPoint = points[0].transform;
            anim = GetComponent<Animator>();
        }


        if (Lose == null)
        {
            Lose = GameObject.FindWithTag("LOSE");
        }

        if (Lose != null)
        {
            if (Lose.activeSelf == true)
            {
                this.enabled = false;
            }
            else
            {
                this.enabled = true;
            }
        }
       

        point = currentPoint.position - transform.position;
        
        MoveToPoint();

        //Animacje zombie

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
            points[0].transform.position = pointZero;
            currentPoint = points[0].transform;
            chasing = false;
            territoryCol.enabled = true;
        }

        if(chase.gameObject.tag == "CandyBite")
        {
            //StartCoroutine(Territory(2, true));

            currentPoint.position = chase.gameObject.transform.position;
            
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "Player")
        {
            speed = startSpeed;

            StopAllCoroutines();
           
           // StartCoroutine(Territory(0, false));

            if (currentPoint == points[i])
            {
                currentPoint.position = points[i].transform.position;
            }

           // StartCoroutine(Territory(3, true));
        }
    }
    

    private void OnDrawGizmos()
    {

        foreach(GameObject point in points)
        {
            Gizmos.DrawWireSphere(point.transform.position, 0.1f);
           // Gizmos.DrawLine(point.transform.position, point.transform.position);
        }

        for(int i = 0; i < points.Count; i++)
        {
           
            if(i == points.Count)
            {
                Gizmos.DrawLine(points[i].transform.position, points[0].transform.position);
            }
            else
            {
                Gizmos.DrawLine(points[i].transform.position, points[i++].transform.position);
            }
        }

       
        //Gizmos.DrawLine(points[i].transform.position, points[i++].transform.position);
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
        points[0].transform.position = player.transform.position;
        currentPoint = points[0].transform;
        StartCoroutine(PlayerPos());
    }

    public IEnumerator Territory(float sek, bool isIt)
    {
        yield return new WaitForSeconds(sek);
        territoryCol.enabled = isIt;
    }



}
