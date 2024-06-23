using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
  //  public static Knockback instance;
  //  public float runSpeed = 40f;
  //  private Vector2 moveInput;
    public Rigidbody2D rb;

    public float knockbackDuration = 1;
    public float knockbackPower = 10;

    public bool knockback;
    public float timer;
    public MoveByTouch movement;

    void Start()
    {
        timer = 0;
        movement = this.gameObject.GetComponent<MoveByTouch>();
    }

    public void Update()
    {
        timer += Time.deltaTime;
    }

 /*   void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.velocity = moveInput * runSpeed;
    }*/

    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            knockback = true;
            Debug.Log(knockback);
            timer = 0;
            StartCoroutine(KnockbackPl(knockbackDuration, knockbackPower, col.gameObject.transform));
        }

    }

    public IEnumerator KnockbackPl(float duration, float power, Transform obj)
    {
        
        Debug.Log("Knockback");

        while(duration > timer)
        {
           yield return new WaitForEndOfFrame();
           Vector2 direction = (obj.transform.position - this.transform.position).normalized;
           rb.AddForce(-direction * power, ForceMode2D.Force);
        }

            yield return 0;

        knockback = false;
    }
}
