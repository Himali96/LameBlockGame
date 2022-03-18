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
    public float downForce;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundRadius;
    public LayerMask groundLayerMask;
    public bool isGrounded, isJumping, isGameOver, isReadyToStartCar, isOnMovableGround;

    [Header("Animation Properties")]
    //public Animator animator;

    private Rigidbody2D rigidBody2D;

    public static PlayerBehaviour _instance;

    float run, jump, crouch;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        Physics.IgnoreLayerCollision(3, 6, (rigidBody2D.velocity.y > 0.0f));

        //animator = GetComponent<Animator>();
    }
    private void Update()
    {
        Physics.IgnoreLayerCollision(3, 6, (rigidBody2D.velocity.y < 0.0f));
    }
    void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayerMask);

        run = Input.GetAxisRaw("Horizontal");
        crouch = Input.GetAxisRaw("Vertical");

        Jump();

        if (run > 0)
        {
            Move();
        }
        else if (run < 0)
        {
            Move();
        }
        else if (isGrounded)
        {
            if(!isOnMovableGround)
                rigidBody2D.velocity = Vector2.zero;
            Jump();
        }
        if (isJumping && crouch < 0)
        {
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, verticalForce * downForce);
        }
    }

    void Move()
    {
        run = Flip(run);
        rigidBody2D.velocity = new Vector2(run * horizontalForce, rigidBody2D.velocity.y);
    }

    void Jump()
    {
        jump = Input.GetAxisRaw("Jump");
        if (jump > 0)
        {
            if (isGrounded || isOnMovableGround)
            {
                rigidBody2D.velocity = new Vector2(0, verticalForce);
                isJumping = true;
            }
        }
        else if (isGrounded) isJumping = false;
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

    public void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "Seesaw")
        {
            rigidBody2D.constraints = RigidbodyConstraints2D.None;
        }
        else
        {
            rigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            transform.eulerAngles = Vector3.zero;
        }

        if (col.gameObject.tag == "MovableGround")
        {
            isOnMovableGround = true;
            rigidBody2D.velocity = new Vector2(-2, rigidBody2D.velocity.y);
        } else
        {
            isOnMovableGround = false;
        }

        if (col.gameObject.tag == "Car")
        {
            isOnMovableGround = true;
            isReadyToStartCar = true;
        } else
        {
            isReadyToStartCar = false;
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Car")
        {
            isOnMovableGround = false;
            isReadyToStartCar = true;
        }
    }
}