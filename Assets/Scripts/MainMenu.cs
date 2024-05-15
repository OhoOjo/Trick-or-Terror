using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour 
{
    public GameObject levelManager;
    public LevelManager levelM;


    public GameObject level;
    public GameObject main;

    // [SerializeField] GameObject Pause;



    void Start()
    {
        levelManager = GameObject.FindWithTag("LevelManager");
        // Pause.SetActive(false);
        // LoadPosition();
        level = GameObject.FindWithTag("Level");
        level.SetActive(false);

        main = GameObject.FindWithTag("MainBut");
        main.SetActive(true);


        if (levelManager == null)
        {
            return;
        }

        if (levelManager != null)
        {
            levelM = levelManager.GetComponent<LevelManager>();
        }

    }
    public void PlayGame()
    {
        SceneManager.LoadScene("LVL1");
    }

    public void GoToLvl2()
    {
        SceneManager.LoadScene("LVL2");
    }

    public void GoToLvl3()
    {
        SceneManager.LoadScene("LVL3");
    }

    public void QuitGame()
    {
        
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void LevelMenu()
    {
        level.SetActive(true);
        main.SetActive(false);
    }

    public void Back()
    {
        level.SetActive(false);
        main.SetActive(true);
    }



    public void PauseMenu()
    {
       // PlayerPrefs.SetInt("SavedScene", SceneManager.GetActiveScene().buildIndex);
       
       // SceneManager.LoadScene("Menu");
      
        Debug.Log("Player position saved");
    }


}
