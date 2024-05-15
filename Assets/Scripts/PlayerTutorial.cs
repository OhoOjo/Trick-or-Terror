using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTutorial : MonoBehaviour
{
    public Collider2D zombieCol;
    public GameObject zombie;
   
    public bool Tutorial4 = false;

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();


        if (Input.touchCount > 0 && scene.name == "LVL1")
        {
            zombie = GameObject.FindWithTag("Enemy");
            
        }

        if (zombie != null)
        {
            zombieCol = zombie.GetComponent<CircleCollider2D>();
        }
        else
        {
            return;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col == zombieCol)
        {
            Tutorial4 = true;
        }
    }
}
