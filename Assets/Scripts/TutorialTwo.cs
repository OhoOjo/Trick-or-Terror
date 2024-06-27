using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTwo : MonoBehaviour
{

    public GameObject TutorialPart;
    public GameObject TutorialPart2;
    public GameObject Cutscene1;
    public GameObject Cutscene2;
    public GameObject TutorialPart3;
    public GameObject TutorialPart6;
    public GameObject TutorialPart7;
    public GameObject TutorialNextPart;

    public GameObject zombiePrefab;
    public GameObject zombieTutorial;

    public GameObject player;
    private PlayerTutorial playerTut;

    public bool canTutorial6;
    public bool canTutorial6end = true;
    private MoveByTouch MoveByT;
    public Collider2D Tutorial2Col;

    public bool canPart = false;
    public GameObject PartOne;


    public bool canPartThree = false;
    private float startSpeed;

    // Start is called before the first frame update
    void Start()
    {
        // TutorialPart.SetActive(false);

        player = GameObject.FindWithTag("Player");
        MoveByT = player.GetComponent<MoveByTouch>();
        playerTut = player.GetComponent<PlayerTutorial>();
        startSpeed = MoveByT.runSpeed;
        MoveByT.enabled = true;
        zombiePrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

       
        canPart = PartOne.GetComponent<Tutorial>().canPartTwo;

        if (TutorialPart.activeSelf == true && canPart == true| TutorialPart6.activeSelf == true && canPart == true | TutorialPart7.activeSelf == true && canPart == true)
        {
            MoveByT.rb.bodyType = RigidbodyType2D.Static;
            MoveByT.animator.SetFloat("SpeedX", 0f);
            MoveByT.animator.SetFloat("SpeedY", 0f);
            MoveByT.runSpeed = 0f;
            MoveByT.enabled = false;
        }

        if (TutorialPart.activeSelf == false && TutorialPart6.activeSelf == false && TutorialPart7.activeSelf == false && canPart == true)
        {
            MoveByT.enabled = true;
            MoveByT.runSpeed = startSpeed;
            MoveByT.rb.bodyType = RigidbodyType2D.Dynamic;
        }

        if(TutorialPart3.activeSelf == true && Input.touchCount > 0)
        {
    
                TutorialPart3.SetActive(false);
                StopAllCoroutines();
                Destroy(zombieTutorial);
             zombiePrefab.SetActive(true);
            
        }

        canTutorial6 = playerTut.Tutorial4;

        if(canTutorial6 == true && canTutorial6end == true)
        {
            TutorialPart6.SetActive(true);
            StartCoroutine(WaitaSeceh());
        }

        if(TutorialPart7.activeSelf == true)
        {
            StartCoroutine(WaitaSecW());
        }
    }

   
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            TutorialPart.SetActive(true);
            StartCoroutine(WaitaSec());
        }
    }

    public IEnumerator WaitaSec()
    {
        Debug.Log("WaitAsEC");
        yield return new WaitForSeconds(2.5f);

            TutorialPart.SetActive(false);
            Tutorial2Col.enabled = false;
            TutorialPart2.SetActive(true);
            StartCoroutine(WaitaSecT());
        
    }

    public IEnumerator WaitaSecT()
    {
        yield return new WaitForSeconds(2.5f);
            TutorialPart2.SetActive(false);
            Cutscene1.SetActive(true);
            StartCoroutine(WaitaSecA());
        
    }

    public IEnumerator WaitaSecA()
    {
        yield return new WaitForSeconds(5f);

            Cutscene1.SetActive(false);
            Cutscene2.SetActive(true);
            StartCoroutine(WaitaSecB());

    }

    public IEnumerator WaitaSecB()
    {
        yield return new WaitForSeconds(5f);

            Cutscene2.SetActive(false);
        TutorialPart3.SetActive(true);
            StopAllCoroutines();
    }

    public IEnumerator WaitaSeceh()
    {
        
        yield return new WaitForSeconds(1);

            if (Input.touchCount > 0)
            {
                canTutorial6end = false;
                TutorialPart6.SetActive(false);
                TutorialPart7.SetActive(true);
            }
        
    }

    public IEnumerator WaitaSecW()
    {

        yield return new WaitForSeconds(1);

            if (Input.touchCount > 0)
            {
                TutorialPart7.SetActive(false);
                TutorialNextPart.SetActive(true);
                canPartThree = true;
            }
        
    }
}