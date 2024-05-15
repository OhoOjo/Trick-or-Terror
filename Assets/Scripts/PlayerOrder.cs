using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrder : MonoBehaviour
{


    public GameObject player;
    private int ord;
    private SpriteRenderer playerRend;
    private int ordThis;
    
    public GameObject parentMaybe;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
       
        playerRend = player.GetComponent<SpriteRenderer>();

        ordThis = this.gameObject.GetComponent<SpriteRenderer>().sortingOrder;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRend == null)
        {
            return;
        }


        ord = playerRend.sortingOrder;
        //Debug.Log(ordThis);

        if(this.gameObject.tag == "TreeAndSome")
        {
            

            if (player.transform.position.y <= parentMaybe.transform.position.y && ord < ordThis)
            {
                ord = ordThis + 1;
            }

            if (player.transform.position.y >= parentMaybe.transform.position.y && ord > ordThis)
            {
                ord = ordThis - 1;
            }

            
        }
        
        if(this.gameObject.tag != "TreeAndSome")
        {
            if (player.transform.position.y <= parentMaybe.transform.position.y && ord < ordThis)
            {
                ord = ordThis + 1;
                playerRend.sortingOrder = ord;
            }

            if (player.transform.position.y >= parentMaybe.transform.position.y && ord > ordThis)
            {
                ord = ordThis - 1;
                playerRend.sortingOrder = ord;
            }
        }

       if(ord < 0)
        {
            ord = 0;
            playerRend.sortingOrder = ord;
        }
    }

}
