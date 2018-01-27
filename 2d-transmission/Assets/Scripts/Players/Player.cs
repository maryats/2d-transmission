using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpforce; // Force applied for jumping
    public float jumptime; // Maximum jump time allowed
    public float jumptimecounter; // Tracks how long you have been jumping

    public bool grounded; // Track if player is on ground
    public bool stopjump;
    public Collider2D playercollider; // Colliders to check is these objects are touching each other
    public Collider2D obstaclecollider;


    Rigidbody2D rb;
    Animator anim;
    int runHash = Animator.StringToHash("Run");
    int idleHash = Animator.StringToHash("Idle");
    int stateHash = Animator.StringToHash("State");
    bool facingRight = true;

    [SerializeField]
    Transform[] groundPoints;

   public float speed = 10;

    private void Start()
    {
        jumptimecounter = jumptime;
        playercollider = GetComponent<Collider2D>();
        obstaclecollider = GameObject.FindGameObjectWithTag("Obstacle").GetComponent<Collider2D>();
        
        anim = GetComponent<Animator>();
        anim.SetTrigger(idleHash);
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        grounded = playercollider.IsTouching(obstaclecollider);



        float jumplen = Input.GetAxis("Jump");

        if (Input.GetKey("space"))
        {
            Debug.Log(jumptimecounter);
            if (grounded)
            {
                rb.velocity = new Vector2(jumplen, jumpforce);
                stopjump = false;
            }
        }
        if ((Input.GetKey("space")) && !stopjump)
        {
            if (jumptimecounter > 0)
            {
                rb.velocity = new Vector2(jumplen, jumpforce);
                jumptimecounter -= Time.deltaTime;
                Debug.Log(jumptimecounter);
            }
            else if (jumptimecounter < 0)
            {
                stopjump = true;
            }

        }
    }

    private void FixedUpdate()
    {
        

    float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);
    }

    void HandleMovement(float horizontal)
    {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        anim.SetFloat("speed",Mathf.Abs( horizontal));

    }

    void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public void Pickup()
    {

    }

    public void Transmit()
    {

    }
}
