using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
  //  public static MoveByTouch instance;

    public Animator animator;

    public Joystick joystick;

    float startSpeed;
    public float runSpeed = 40f;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    [HideInInspector]
    public Vector2 moveDirection;
    //   [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    // private bool isFacingRight = true;

    public Rigidbody2D rb;
   // public float knockbackForce = 20;

   // private Vector2 moveInput;

  /*  void Awake()
    {
        instance = this;
    }*/

    void Start()
    {
        startSpeed = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
      //  moveInput.x = Input.GetAxisRaw("Horizontal");
      //  moveInput.y = Input.GetAxisRaw("Vertical");

       // moveInput.Normalize();

      //  rb.velocity = moveInput * runSpeed;
       
        animator.SetFloat("SpeedX", horizontalMove);
        animator.SetFloat("SpeedY", verticalMove);

        ProcessInputs();

        //Debug.Log(horizontalMove);
       // Debug.Log(verticalMove);
    }


  /*  public IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj)
    {
        float timer = 0;

        while(knockbackDuration > timer)
        {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        }

        yield return 0;
    }*/

    void FixedUpdate()
    {
        Move();
    }


    void ProcessInputs()
    {
       
        float moveX = joystick.Horizontal;
        float moveY = joystick.Vertical;

        horizontalMove = moveX;
        verticalMove = moveY;

        moveDirection = new Vector2(moveX, moveY).normalized;


    }

    public void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * runSpeed, moveDirection.y * runSpeed);

    }


   /* void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("collision");
        Vector2 direction = (col.transform.position + transform.position).normalized;

        if (col.gameObject.tag == "Enemy")
        {
            runSpeed = 0f;
            rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);
            runSpeed = startSpeed;
        }
    }*/

}





//Fun stuff but I don't need it for now

/* for (int i = 0; i < Input.touchCount; i++)
 {
     Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
     Debug.DrawLine(Vector3.zero, touchPosition, Color.white);
 }*/

/*
if(Input.touchCount > 0)
{
    Touch touch = Input.GetTouch(0);
    Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
    touchPosition.z = 0f;
    transform.position = touchPosition;
}*/