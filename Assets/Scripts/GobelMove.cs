using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class GobelMove : MonoBehaviour
{
    
    public float speed;
 
    public bool facingRight = true;
    public bool isGround = true;

    private Rigidbody2D rb;
    private Vector3 velocity;

    public Animator animator;

    GameControl GameControl;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameControl = GameObject.Find("Main Camera").GetComponent<GameControl>();
    }

    private void Update()
    {


        if (GameControl.isGameActive == true)
        {

            if (Input.GetKey(KeyCode.D) && isGround == true)  // right move
            {
                rb.velocity = new Vector2(speed, 0);
                animator.SetFloat("Speed", speed);
                if (facingRight == false)
                    Flip();
            }

            else if (Input.GetKey(KeyCode.A) && isGround == true) // left move
            {
                rb.velocity = new Vector2(-speed, 0);
                animator.SetFloat("Speed", speed);
                if (facingRight == true)
                    Flip();

            }

            else if (isGround == true)
            {
                rb.velocity = new Vector2(0, 0);
                animator.SetFloat("Speed", 0);
            }

        }
        else
        {
            animator.SetFloat("Speed", 0);
            rb.velocity = new Vector2(0, 0);
        }
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            isGround = true;
        }
    }

    void Flip ()
    {

        // face flip
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

}
