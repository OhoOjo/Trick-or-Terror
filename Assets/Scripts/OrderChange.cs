using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderChange : MonoBehaviour
{
    public GameObject player;
    private int ord;
    private SpriteRenderer playerRend;

    public List<GameObject> Children = new List<GameObject>();
    public List<float> TransformY = new List<float>();

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerRend = player.GetComponent<SpriteRenderer>();

        GetAllChildren();
    }

    void Update()
    {
        ord = playerRend.sortingOrder;
        //Debug.Log(ord);
        foreach (float n in TransformY)
        {
            /*
            if (player.transform.position.y < n)
            {
                
                foreach(GameObject child in Children)
                {
                    ord >= (child.GetComponent<SpriteRenderer>().sortingOrder);
                    Debug.Log(ord);
                }
            }

            if (player.transform.position.y > n)
            {
                Debug.Log("Playerssssssss");
                foreach (GameObject child in Children)
                {
                    ord <= (child.GetComponent<SpriteRenderer>().sortingOrder);
                    Debug.Log(ord);
                }
            }*/
        }
       


    }

    private void GetAllChildren()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Building")
            {
                Children.Add(child.gameObject);
                TransformY.Add(child.gameObject.GetComponent<Transform>().position.y);

            }
        }

        
    }

}
