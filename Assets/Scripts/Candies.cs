using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candies : MonoBehaviour
{

    public GameObject Candy1;
    public GameObject Candy2;
    public GameObject Candy3;

    public bool candySpawned;
    public int candyAmount;

    public GameObject player;
    public Vector3 playerPos;

    public GameObject prefabCandy;

    public float speed;

    public Vector3 throwPoint;

    // Start is called before the first frame update
    void Start()
    {

        Candy1.SetActive(false);
        Candy2.SetActive(false);
        Candy3.SetActive(false);

        candySpawned = false;
        candyAmount = 0;

        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, player.transform.position.y + 0.4f, 0f);


        if (Candy3.activeSelf == false && Candy2.activeSelf == false && Candy1.activeSelf == true)
        {
            candyAmount = 1;
        }

        if (Candy3.activeSelf == false && Candy2.activeSelf == true && Candy1.activeSelf == true)
        {
            candyAmount = 2;
        }

        if (Candy3.activeSelf == true && Candy2.activeSelf == true && Candy1.activeSelf == true)
        {
            candyAmount = 3;
        }


        if (Input.touchCount > 0)
        {

            if (Candy3.activeSelf == true | Candy2.activeSelf == true | Candy1.activeSelf == true)
            {

                if (Input.GetTouch(0).tapCount == 2)
                {
                    
                    Touch touch = Input.GetTouch(0);
                    //Double tap
                    Vector3 p = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

                    //candySpawned = false;

                    if (candyAmount == 1 && candySpawned == false)
                    {
                        throwPoint = new Vector3(p.x, p.y, 0f);
                        GameObject candy = Instantiate(prefabCandy, playerPos , Quaternion.identity);
                        candySpawned = true;
                        Candy1.SetActive(false);
                    }

                    if (candyAmount == 2 && candySpawned == false)
                    {
                        throwPoint = new Vector3(p.x, p.y, 0f);
                        GameObject candy = Instantiate(prefabCandy, playerPos, Quaternion.identity);
                        candySpawned = true;
                        Candy2.SetActive(false);
                    }

                    if (candyAmount == 3 && candySpawned == false)
                    {
                        throwPoint = new Vector3(p.x, p.y, 0f);
                        GameObject candy = Instantiate(prefabCandy, playerPos, Quaternion.identity);
                        candySpawned = true;
                        Candy3.SetActive(false);
                    }

                    StartCoroutine(Spawn());

                }

                if (candySpawned == true)
                {
                    candyAmount = candyAmount - 1;
                }
            }

          
            
        }


    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.7f);
        candySpawned = false;
    }
}


/*
 * else if (Candy2.activeSelf == true && candySpawned == false)
                    {
                        candySpawned = true;
                        Instantiate(prefabCandy, new Vector3(p.x, p.y, 0f), Quaternion.identity);
                        Candy2.SetActive(false);
                    }
                    else if (Candy1.activeSelf == true && candySpawned == false)
                    {
                        candySpawned = true;
                        Instantiate(prefabCandy, new Vector3(p.x, p.y, 0f), Quaternion.identity);
                        Candy1.SetActive(false);
                    }*/
