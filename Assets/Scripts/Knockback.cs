using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public static Knockback instance;
    public float runSpeed = 40f;
    private Vector2 moveInput;
    public Rigidbody2D rb;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb.velocity = moveInput * runSpeed;
    }

    public IEnumerator KnockbackPl(float knockbackDuration, float knockbackPower, Transform obj)
    {
        Debug.Log("Knockback");
        float timer = 0;

        while (knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        }

        yield return 0;
    }
}
