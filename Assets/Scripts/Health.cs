using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public GameObject Candies;
    public Candies candieScript;

    public GameObject player;
    public MoveByTouch Movebytouch;

    public Slider HealthSlider;
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject Lose;
    //  public float currentTime = 0f;
    //  public float startingTime = 2f;
    // public Animator animator;
    AudioSource collectSound;


    // Start is called before the first frame update
    void Start()
    {
        Lose = GameObject.FindWithTag("LOSE");
        Lose.SetActive(false);
        gameObject.tag = "Player";
        currentHealth = maxHealth;
        HealthSlider = GetComponent<Slider>();
        SetMaxHealths();

        Candies = GameObject.FindWithTag("Candies");
        candieScript = Candies.GetComponent<Candies>();

        player = GameObject.FindWithTag("Player");
        Movebytouch = player.GetComponent<MoveByTouch>();
        // currentTime = startingTime;
        collectSound = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        SetHealths();

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            TakeDamages(1);
            Debug.Log("Damage Ouch");


            /*  if(currentHealth < maxHealth)
              {
                  currentHealth += 15;

              }*/

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

       
        }

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "CandyBite")
        {
            collectSound.Play();
        }
    }



    /*  void Back()
      {
          currentTime = startingTime;
      }*/

    // Update is called once per frame
    void Update()
    {
        // currentTime -= 1 * Time.deltaTime;
      //  animator.SetFloat("Health", currentHealth);


        /*  if (currentTime <= 0)
           {
              currentTime = 0;
              TakeDamage(5);
              Back();
           }*/

        if (currentHealth <= 0)
        {
            maxHealth = 0;
        }




    }



    public void TakeDamages(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            HealthSlider.value = 0;
            Time.timeScale = 0;
            Lose.SetActive(true);

            Movebytouch.enabled = false;
            candieScript.enabled = false;
            
            //  Destroy(gameObject);
            //SceneManager.LoadScene("MainMenu");

        }

    }


    public void SetMaxHealths()
    {
        HealthSlider.maxValue = maxHealth;

    }

    public void SetHealths()
    {
        HealthSlider.value = currentHealth;
    }


}