using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    int thisNum;
    string currentScene;

    public LevelManager levelM;
    // Start is called before the first frame update
    void Start()
    {
        thisNum = GameObject.FindGameObjectsWithTag("LevelManager").Length;
        currentScene = SceneManager.GetActiveScene().name; 
        levelM = this.gameObject.GetComponent<LevelManager>();
    }

    void Awake()
    {
       
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {

        //Checks every frame
        if (SceneManager.GetActiveScene().name != currentScene)
        {
            // Debug.Log(SceneManager.GetActiveScene().name);
            currentScene = SceneManager.GetActiveScene().name;
        }
        else if (SceneManager.GetActiveScene().name == currentScene)
        {
            // Debug.Log(canvasNum);
            thisNum = GameObject.FindGameObjectsWithTag("LevelManager").Length;
        }



        if (thisNum >= 2)
        {
           // levelM.loadData();
            Destroy(this.gameObject);
        }

    }

}
