using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyThrow : MonoBehaviour
{
    public GameObject Candies;
    public Candies scriptCandies;
    public Vector3 throwPoint;

    public GameObject candyBite;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Candies = GameObject.FindWithTag("Candies");
        scriptCandies = Candies.GetComponent<Candies>();
        throwPoint = scriptCandies.throwPoint;
        Debug.Log(throwPoint);
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, throwPoint, speed * Time.deltaTime);
        if(transform.position == throwPoint)
        {
            Instantiate(candyBite, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
}
