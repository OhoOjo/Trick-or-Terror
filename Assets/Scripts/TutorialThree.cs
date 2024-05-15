using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialThree : MonoBehaviour
{
    public GameObject Tutorial1;
    public Collider2D TutorialCol;
    public GameObject Tutorial2;
    public Collider2D TutorialCol2;

    public GameObject PartTwo;

    public GameObject player;
    private MoveByTouch MoveByT;
    private float startSpeed;
    public bool canPartThree;
    public bool second = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        MoveByT = player.GetComponent<MoveByTouch>();
        MoveByT.enabled = true;
        startSpeed = MoveByT.runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        canPartThree = PartTwo.GetComponent<TutorialTwo>().canPartThree;

        if (Tutorial1.activeSelf == true && canPartThree == true | Tutorial2.activeSelf == true && canPartThree == true)
        {
            MoveByT.rb.bodyType = RigidbodyType2D.Static;
            MoveByT.animator.SetFloat("SpeedX", 0f);
            MoveByT.animator.SetFloat("SpeedY", 0f);
            MoveByT.runSpeed = 0f;
            MoveByT.enabled = false;
        }

        if (Tutorial1.activeSelf == false && canPartThree == true && Tutorial2.activeSelf == false)
        {
            MoveByT.enabled = true;
            MoveByT.runSpeed = startSpeed;
            MoveByT.rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && second == false)
        {
            Tutorial1.SetActive(true);
            StartCoroutine(WaitaSec());
        }

        if (col.gameObject.tag == "Player" && second == true)
        {
            Tutorial2.SetActive(true);
            StartCoroutine(WaitaSeco());
        }
    }

    public IEnumerator WaitaSec()
    {
      
        yield return new WaitForSeconds(2.5f);

            Tutorial1.SetActive(false);
            TutorialCol.enabled = false;
        second = true;

    }

    public IEnumerator WaitaSeco()
    {

        yield return new WaitForSeconds(4f);

        Tutorial2.SetActive(false);
        TutorialCol2.enabled = false;
        second = true;

    }
}
