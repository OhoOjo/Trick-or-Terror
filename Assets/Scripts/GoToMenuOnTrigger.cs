using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToMenuOnTrigger : MonoBehaviour
{
    public GameObject Candies;
    public Candies candieScript;

    public GameObject player;
    public MoveByTouch Movebytouch;


    public GameObject levelManager;
    public LevelManager levelM;
    public int LVL1 = 0;
    public int LVL2 = 0;
    public int LVL3 = 0;
    public int LVL4 = 0;
    public int LVL5 = 0;
    public int LVL6 = 0;
    public int LVL7 = 0;
    public int LVL8 = 0;
    public int LVL9 = 0;

    public GameObject Win;

    public void Start()
    {


        Candies = GameObject.FindWithTag("Candies");
        candieScript = Candies.GetComponent<Candies>();

        player = GameObject.FindWithTag("Player");
        Movebytouch = player.GetComponent<MoveByTouch>();
        Win = GameObject.FindWithTag("WIN");
        Win.SetActive(false);

    }

    public void Update()
    {

        levelManager = GameObject.FindWithTag("LevelManager");


        if (levelManager == null)
        {
            return;
        }

        if (levelManager != null)
        {
            levelM = levelManager.GetComponent<LevelManager>();
            levelM.LVL1 = LVL1;
            levelM.LVL2 = LVL2;
        }
    }

    public void LVL1Over()
    {
        Time.timeScale = 0;

        if (SceneManager.GetActiveScene().name == "LVL1")
        {
            LVL1 = 1;
            levelM.LVL1 = LVL1;
            StaticLevelData.LVL1(1);
            levelM.saveData(); 
        }

        if (SceneManager.GetActiveScene().name == "LVL2")
        {
            LVL2 = 1;
            levelM.LVL2 = LVL2;
            StaticLevelData.LVL2(1);
            levelM.saveData();
        }

        if (SceneManager.GetActiveScene().name == "LVL3")
        {
            LVL3 = 1;
            levelM.LVL3 = LVL3;
            StaticLevelData.LVL3(1);
            levelM.saveData();
        }

        if (SceneManager.GetActiveScene().name == "LVL4")
        {
            LVL4 = 1;
            levelM.LVL4 = LVL4;
        }

        if (SceneManager.GetActiveScene().name == "LVL5")
        {
            LVL5 = 1;
            levelM.LVL5 = LVL5;
        }

        if (SceneManager.GetActiveScene().name == "LVL6")
        {
            LVL6 = 1;
            levelM.LVL6 = LVL6;
        }

        if (SceneManager.GetActiveScene().name == "LVL7")
        {
            LVL7 = 1;
            levelM.LVL7 = LVL7;
        }

        if (SceneManager.GetActiveScene().name == "LVL8")
        {
            LVL8 = 1;
            levelM.LVL8 = LVL8;
        }

        if (SceneManager.GetActiveScene().name == "LVL9")
        {
            LVL9 = 1;
            levelM.LVL9 = LVL9;
        }

        Win.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
       

        if (col.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            Win.SetActive(true);
            // SceneManager.LoadScene("MainMenu");
        }
        //Debug.Log("works...");

        if (SceneManager.GetActiveScene().name == "LVL1" && col.gameObject.tag == "Player")
        {
            LVL1 = 1;
            levelM.LVL1 = LVL1;
            StaticLevelData.LVL1(1);
            levelM.saveData();
        }

        if (SceneManager.GetActiveScene().name == "LVL2" && col.gameObject.tag == "Player")
        {
            LVL2 = 1;
            levelM.LVL2 = LVL2;
            StaticLevelData.LVL2(1);
            levelM.saveData();
        }

        if (SceneManager.GetActiveScene().name == "LVL3" && col.gameObject.tag == "Player")
        {
            LVL3 = 1;
            levelM.LVL3 = LVL3;
            StaticLevelData.LVL3(1);
            levelM.saveData();
        }





    }
}
