using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpforce; // Force applied for jumping
    
    public bool grounded; // Track if player is on ground
    public bool jump = false;

    [SerializeField]
    private Transform[] groundPoints; // used to check if the sprite is on ground

    [SerializeField]
    private float groundradius; // 

    [SerializeField]
    private LayerMask whatisground;
    private bool isgrounded;

 	  public PlayerHealth playerHealth;
	  private const int DAMAGE_AMOUNT = 5;

    Rigidbody2D rb;
    Animator anim;
    int runHash = Animator.StringToHash("Run");
    int idleHash = Animator.StringToHash("Idle");
    int stateHash = Animator.StringToHash("State");
    bool facingRight = true;

   public float speed = 1;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger(idleHash);
        rb = GetComponent<Rigidbody2D>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        grounded = IsGrounded();
        HandleJump();
        ResetActions();
    }  

public void HandleJump()
    {
        if(grounded && jump)
            rb.AddForce(new Vector2(0, jumpforce));
    }

   public void HandleMovement(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        anim.SetFloat("speed",Mathf.Abs( horizontal));
    }

    public void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }

    public bool IsGrounded()
    {
        if (rb.velocity.y < 0.00001)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundradius, whatisground);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if ((colliders[i]).gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
     return false;
    }

    private void ResetActions()
    {
        jump = false;
    }
    
    public bool IsFacingRight()
    {
        return facingRight;
    }
}
