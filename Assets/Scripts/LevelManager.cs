using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public Scene scene;

    public int LVL1 = 0;
    public int LVL2 = 0;
    public int LVL3 = 0;
    public int LVL4 = 0;
    public int LVL5 = 0;
    public int LVL6 = 0;
    public int LVL7 = 0;
    public int LVL8 = 0;
    public int LVL9 = 0;

    public GameObject LevelButtons;
    [HideInInspector]
    public GameObject lvl1;
    [HideInInspector]
    public GameObject lvl2;
    [HideInInspector]
    public GameObject lvl3;
    [HideInInspector]
    public GameObject lvl4;
    [HideInInspector]
    public GameObject lvl5;
    [HideInInspector]
    public GameObject lvl6;
    [HideInInspector]
    public GameObject lvl7;
    [HideInInspector]
    public GameObject lvl8;
    [HideInInspector]
    public GameObject lvl9;

    AudioSource tapSound;


    // Start is called before the first frame update
    void Start()
    {
        loadData();
        tapSound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        LVL1 = StaticLevelData.lvl1;
        LVL2 = StaticLevelData.lvl2;
        LVL3 = StaticLevelData.lvl3;
        LVL4 = StaticLevelData.lvl4;
        LVL5 = StaticLevelData.lvl5;
        LVL6 = StaticLevelData.lvl6;
        LVL7 = StaticLevelData.lvl7;
        LVL8 = StaticLevelData.lvl8;
        LVL9 = StaticLevelData.lvl9;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    tapSound.Play();
                    break;
                case TouchPhase.Ended:
                    break;
            }
            
        }

        scene = SceneManager.GetActiveScene();

        if(scene.name == "MainMenu")
        {
            LevelButtons = GameObject.FindWithTag("Level"); 

            if(LevelButtons != null)
            {
                lvl1 = LevelButtons.transform.GetChild(0).gameObject;
                lvl2 = LevelButtons.transform.GetChild(1).gameObject;
                lvl3 = LevelButtons.transform.GetChild(2).gameObject;
                lvl4 = LevelButtons.transform.GetChild(3).gameObject;
                lvl5 = LevelButtons.transform.GetChild(4).gameObject;
                lvl6 = LevelButtons.transform.GetChild(5).gameObject;
                lvl7 = LevelButtons.transform.GetChild(6).gameObject;
                lvl8 = LevelButtons.transform.GetChild(7).gameObject;
                lvl9 = LevelButtons.transform.GetChild(8).gameObject;
            } 
        }

        if(LevelButtons == null)
        {
            return;
        }

        if(LVL1 == 1)
        {
            Button lvlButton2 = lvl2.GetComponent<Button>();
            lvlButton2.interactable = true;

            GameObject locked = lvl2.transform.GetChild(1).gameObject;
            locked.SetActive(false);
            saveData();
        }

        if (LVL2 == 1)
        {
            
            Button lvlButton3 = lvl3.GetComponent<Button>();
            lvlButton3.interactable = true;

            GameObject locked = lvl3.transform.GetChild(1).gameObject;
            locked.SetActive(false);
            saveData();
        }

        if (LVL3 == 1)
        {
            
            Button lvlButton4 = lvl4.GetComponent<Button>();
            lvlButton4.interactable = true;

            GameObject locked = lvl4.transform.GetChild(1).gameObject;
            locked.SetActive(false);
            saveData();
        }

        if (LVL4 == 1)
        {

            Button lvlButton5 = lvl5.GetComponent<Button>();
            lvlButton5.interactable = true;

            GameObject locked = lvl5.transform.GetChild(1).gameObject;
            locked.SetActive(false);
            saveData();
        }

        if (LVL5 == 1)
        {

            Button lvlButton6 = lvl6.GetComponent<Button>();
            lvlButton6.interactable = true;

            GameObject locked = lvl6.transform.GetChild(1).gameObject;
            locked.SetActive(false);
            saveData();
        }

        if (LVL6 == 1)
        {

            Button lvlButton6 = lvl6.GetComponent<Button>();
            lvlButton6.interactable = true;

            GameObject locked = lvl6.transform.GetChild(1).gameObject;
            locked.SetActive(false);
            saveData();
        }

        if (LVL7 == 1)
        {

            Button lvlButton8 = lvl8.GetComponent<Button>();
            lvlButton8.interactable = true;

            GameObject locked = lvl8.transform.GetChild(1).gameObject;
            locked.SetActive(false);
            saveData();
        }

        if (LVL8 == 1)
        {

            Button lvlButton9 = lvl9.GetComponent<Button>();
            lvlButton9.interactable = true;

            GameObject locked = lvl9.transform.GetChild(1).gameObject;
            locked.SetActive(false);
            saveData();
        }

    }


    public void saveData()
    {
        PlayerPrefs.SetInt("lvl1", LVL1);
        PlayerPrefs.SetInt("lvl2", LVL2);
        PlayerPrefs.SetInt("lvl3", LVL3);
        PlayerPrefs.SetInt("lvl4", LVL4);
        PlayerPrefs.SetInt("lvl5", LVL5);
        PlayerPrefs.SetInt("lvl6", LVL6);
        PlayerPrefs.SetInt("lvl7", LVL7);
        PlayerPrefs.SetInt("lvl8", LVL8);
        PlayerPrefs.SetInt("lvl9", LVL9);
    }

    public void loadData()
    {
        LVL1 = PlayerPrefs.GetInt("lvl1");
        LVL2 = PlayerPrefs.GetInt("lvl2");
        LVL3 = PlayerPrefs.GetInt("lvl3");
        LVL4 = PlayerPrefs.GetInt("lvl4");
        LVL5 = PlayerPrefs.GetInt("lvl5");
        LVL6 = PlayerPrefs.GetInt("lvl6");
        LVL7 = PlayerPrefs.GetInt("lvl7");
        LVL8 = PlayerPrefs.GetInt("lvl8");
        LVL9 = PlayerPrefs.GetInt("lvl9");
    }

   

}
