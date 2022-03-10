using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")]
    public float horizontalForce;
    public float verticalForce;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundRadius, run;
    public LayerMask groundLayerMask;
    public bool isGrounded, isCrouching;

    [Header("Animation Properties")]
    //public Animator animator;

    private Rigidbody2D rigidBody2D;

    Vector2 move;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayerMask);

        run = Input.GetAxisRaw("Horizontal");

        Jump();

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Move();
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Move();
        }
        else if (isGrounded)
        {
            rigidBody2D.velocity = Vector2.zero;
            Jump();
        }
    }

    void Move ()
    {
        run = Flip(run);
        rigidBody2D.velocity = new Vector2(run * horizontalForce, rigidBody2D.velocity.y);
    }

    void Jump ()
    {
        if (Input.GetAxisRaw("Jump") > 0f && isGrounded)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, verticalForce);
        }
    }

    private float Flip(float x)
    {
        x = (x > 0) ? 1 : -1;

        transform.localScale = new Vector3(x, 1.0f);
        return x;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        //
    }

}