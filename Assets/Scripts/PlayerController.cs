using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private bool isGrounded;
    private bool Jump;
    [SerializeField]
    private float moveSpeed = 50f;
    [SerializeField]
    private float jumpForce = 100f;
    public Transform groundCheck;
    private float groundCheckRadius = 0.2f;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundCheck = transform.Find("GroundCheck");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump = true;
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, LayerMask.GetMask("Ground"));

        Move(horizontal);
    }


    private void Move(float horizontal)
    {
        rb2d.velocity = new Vector2(horizontal * moveSpeed,rb2d.velocity.y);
        anim.SetFloat("Moving",Mathf.Abs(horizontal));
        if(Jump)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x,jumpForce), ForceMode2D.Impulse);
            anim.SetTrigger("Jump");
            Jump = false;
        }

        if(horizontal < 0)
        {
            transform.localScale = new Vector2(-1,1);
        }
        if(horizontal > 0)
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
}
