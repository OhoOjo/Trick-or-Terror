using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Candy : MonoBehaviour
{
    public GameObject Candy1;
    public GameObject Candy2;
    public GameObject Candy3;

    public GameObject child1;
    public GameObject child2;
    public GameObject child3;

   // AudioSource collectSound;

    private CircleCollider2D circleCollider;
    // Start is called before the first frame update
    public void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();

        Candy1 = GameObject.FindWithTag("Candy1");
        Candy2 = GameObject.FindWithTag("Candy2");
        Candy3 = GameObject.FindWithTag("Candy3");

        child1 = Candy1.transform.GetChild(0).gameObject;
        child2 = Candy2.transform.GetChild(0).gameObject;
        child3 = Candy3.transform.GetChild(0).gameObject;

       // collectSound = GetComponent<AudioSource>();
    }

    public void Update()
    {
      
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Destroy(this.gameObject);
            if(child1.activeSelf == false)
            {
                child1.SetActive(true);
            }
            else if(child1.activeSelf == true && child2.activeSelf == false)
            {
                child2.SetActive(true);
            }
            else if(child1.activeSelf == true && child2.activeSelf == true && child3.activeSelf == false)
            {
                child3.SetActive(true);
            }

        }
    }

}
