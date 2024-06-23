using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject pauseBut;

    public GameObject Candies;
    public Candies candieScript;

    public GameObject player;
    public MoveByTouch Movebytouch;

    public GameObject levelManager;
    public LevelManager levelM;
    public GameObject levelManagerPrefab;


    public Scene scene;

    public GameObject Lose;
    public GameObject Win;

    public bool paused;


    void Start()
    {
      
        Lose = GameObject.FindWithTag("LOSE");
        Win = GameObject.FindWithTag("WIN");
       
        pauseBut = GameObject.FindWithTag("Pause");
     
        pauseBut.SetActive(false);
        
        Candies = GameObject.FindWithTag("Candies");
        candieScript = Candies.GetComponent<Candies>();

        player = GameObject.FindWithTag("Player");
        Movebytouch = player.GetComponent<MoveByTouch>();
       

        
    }

    public void Update()
    {
        levelManager = GameObject.FindWithTag("LevelManager");
        levelM = levelManager.GetComponent<LevelManager>();
        scene = SceneManager.GetActiveScene();


        if(paused == true)
        {
            Time.timeScale = 0; 
        }
        else
        {
            Time.timeScale = 1;
        }

    }

    public void BackToMenu()
    {
        levelM.saveData();
        SceneManager.LoadScene("MainMenu");
        levelM.loadData();
        paused = false;

    }

    public void Resume()
    {
        pauseBut.SetActive(false);

        paused = false;
        Debug.Log(Time.timeScale);
    }

    public void Pausing()
    {
        paused = true;
        pauseBut.SetActive(true);
        Debug.Log(Time.timeScale);
       
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(scene.name);
        paused = false;
        levelM.saveData();
       // levelM.loadData();

    }

    public void NextLevel()
    {
        levelM.saveData();

        int i = scene.buildIndex;

            if(scene.buildIndex == i)
            {
                SceneManager.LoadScene(i+1);
            }

        paused = false;
       // levelM.loadData();

    }
}
