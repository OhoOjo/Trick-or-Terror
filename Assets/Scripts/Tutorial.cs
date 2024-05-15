using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [Header("Tutorials")]
    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    public GameObject Tutorial4;
    public GameObject Tutorial5;

    [Header ("Other")]
    public Collider2D Tutorial2Col;

    public GameObject Candy1;
    private bool canTutorial3;
    private bool canTutorial4;
    //private bool canTutorial5;

    public Animator handAnim;

    public GameObject player;
    private MoveByTouch MoveByT;
    private PlayerTutorial playerTut;

    public bool canPartTwo;
    public bool canTutorial6 = false;

    private float startSpeed;


    // Start is called before the first frame update
    void Start()
    {
       
        Tutorial1.SetActive(true);
        canTutorial3 = true;
        canTutorial4 = true;
       // canTutorial5 = true;
        player = GameObject.FindWithTag("Player");
        MoveByT = player.GetComponent<MoveByTouch>();
        MoveByT.enabled = true;
        canPartTwo = false;
        startSpeed = MoveByT.runSpeed;

    }

    // Update is called once per frame
    void Update()
    {


        if(Tutorial1.activeSelf == true | Tutorial2.activeSelf == true | Tutorial3.activeSelf == true | Tutorial4.activeSelf == true | Tutorial5.activeSelf == true)
        {
            MoveByT.rb.bodyType = RigidbodyType2D.Static;
            MoveByT.animator.SetFloat("SpeedX", 0f);
            MoveByT.animator.SetFloat("SpeedY", 0f);
            MoveByT.runSpeed = 0f;
            MoveByT.enabled = false;
        }

        if (Tutorial1.activeSelf == false && Tutorial2.activeSelf == false && Tutorial3.activeSelf == false && Tutorial4.activeSelf == false && Tutorial5.activeSelf == false)
        {
            MoveByT.enabled = true;
            MoveByT.runSpeed = startSpeed;
            MoveByT.rb.bodyType = RigidbodyType2D.Dynamic;
        }


        if (Input.touchCount > 0)
        {
            Tutorial1.SetActive(false);
        }

        if (Tutorial2.activeSelf == true) 
        {
            StartCoroutine(WaitSecondsOne(1f));
        }

        if(Candy1.activeSelf == true && canTutorial3 == true)
        {
            Tutorial3.SetActive(true);
            StartCoroutine(WaitSecondsThree(1f));
        }

        if(Tutorial4.activeSelf == true && canTutorial3 == false && Input.touchCount > 0 && canTutorial4 == true)
        {

                StartCoroutine(WaitSecondsFour(3f));
            
        }

        if (Tutorial5.activeSelf == true && canTutorial4 == false && Input.touchCount > 0)
        {
            
                StartCoroutine(WaitSecondsFive(3f));
            
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            Debug.Log("works");
            Tutorial2.SetActive(true);
        }
    }


    public IEnumerator WaitSecondsOne(float i)
    {
        yield return new WaitForSeconds(i);
  
            if (Input.touchCount > 0)
            {
                Tutorial2.SetActive(false);
                Tutorial2Col.enabled = false;
                StopAllCoroutines();
            }
        
    }


    public IEnumerator WaitSecondsThree(float i)
    {
        yield return new WaitForSeconds(i);
       
            if (Input.touchCount > 0)
            {
                Tutorial3.SetActive(false);
                canTutorial3 = false;
                Tutorial4.SetActive(true);
                handAnim.SetBool("double", true);
                StopAllCoroutines();
            }
        
    }

    public IEnumerator WaitSecondsFour(float i)
    {
        yield return new WaitForSeconds(i);

            Tutorial4.SetActive(false);
            canTutorial4 = false;
            Tutorial5.SetActive(true);
            StopAllCoroutines();
        
    }

    public IEnumerator WaitSecondsFive(float i)
    {
        yield return new WaitForSeconds(i);
            Tutorial5.SetActive(false);
            canPartTwo = true;
          //  canTutorial5 = false;
            StopAllCoroutines();
    }

}
