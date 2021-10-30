using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class playerscript : MonoBehaviour
{
    //Movement and Physics
    public LayerMask groundlayer;
    public bool isGrounded = false;
    public Transform groundcheck;
    public bool facingRight = true;
    public float speed;
    public float move_velocity;
    public float jump;
    private Rigidbody2D playerbody;
    public CapsuleCollider2D playercollider;
    public int jump_count;
    //Dash
    public float dashDistance = 15f;
    bool isDashing;
    public int dashCount;
    //Player Animator
    public Animator animator;
    //Player Combat
    public int lifePoints;
    public float attack_range;
    public Transform attackPos;
    public LayerMask EnemiesLayer;
    public int attack_damage;
    public float attack_rate = 3.7f;
    float nextAttackTime = 0f;


    void Start()
    {
        playercollider = this.gameObject.GetComponent<CapsuleCollider2D>();
        playerbody = this.gameObject.GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(move_velocity));
        animator.SetFloat("Jump_speed", Mathf.Abs(playerbody.velocity.y));
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
        move_velocity = 0;
        if(!isDashing)
        {
            if (h < 0)
            {
                move_velocity -= speed;
            }
            if (h > 0)
            {
                move_velocity += speed;
            }
            playerbody.velocity = new Vector2(move_velocity, playerbody.velocity.y);
        }
    }
    void Update()
    {
        Attack();
        Jump();
        if(dashCount > 0){
        if(CrossPlatformInputManager.GetButtonDown("Dash") && facingRight &&!isGrounded)
        {
            StartCoroutine(Dash(1f));
        }
        if(CrossPlatformInputManager.GetButtonDown("Dash") && !facingRight &&!isGrounded)
        {
            StartCoroutine(Dash(-1f));
        }
        }
        if(isGrounded)
        {
            dashCount = 1;
            jump_count = 2;
        }
    }
    void Attack()
    {
        if(Time.time >= nextAttackTime)
        {
            if (CrossPlatformInputManager.GetButtonDown("Attack"))
            {
                animator.SetTrigger("attack");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attack_range, EnemiesLayer);
                nextAttackTime = Time.time + 1f / attack_rate;
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<Enemies>().TakeDamage(attack_damage);
                }
            }
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void onDrawGizmosSelected()
    {
        if (attackPos == null)
            return;
        Gizmos.DrawWireSphere(attackPos.position, attack_range);
    }
    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
        if (CrossPlatformInputManager.GetButtonDown("Jump") && jump_count > 0)
        {
            playerbody.velocity = new Vector2(move_velocity, jump);
            jump_count--;
        }
    }
    IEnumerator Dash(float direction)
    {
        isDashing = true;
        playerbody.velocity = new Vector2(playerbody.velocity.x, 0f);
        playerbody.AddForce(new Vector2(dashDistance * direction, 0f), ForceMode2D.Impulse);
        float gravity = playerbody.gravityScale;
        playerbody.gravityScale = 0;
        dashCount--;
        yield return new WaitForSeconds(0.2f);
        isDashing = false;
        playerbody.gravityScale = gravity;
    } 
}


