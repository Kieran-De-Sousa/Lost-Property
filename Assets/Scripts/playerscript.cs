using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float dash_velocity;
    public float dash_amount;
    public float dash_recharge_time;
    private float dash_charge;
    private bool can_dash = false;

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
        dash_charge = 0.0f;
        dash_velocity = 0.0f;
    }

    void FixedUpdate()
    {
        animator.SetFloat("Speed", Mathf.Abs(move_velocity*dash_velocity));
        animator.SetFloat("Jump_speed", Mathf.Abs(playerbody.velocity.y));
        float h = Input.GetAxis("Horizontal");
        if (h > 0 && !facingRight)
            Flip();
        else if (h < 0 && facingRight)
            Flip();
        move_velocity = 0;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            move_velocity -= speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            move_velocity += speed;
        }
        playerbody.velocity = new Vector2(move_velocity, playerbody.velocity.y);
    }
    void Update()
    {
        Attack();
        Jump();
        Dash();
        if(isGrounded)
        {
            jump_count = 2;
        }
        playerbody.velocity = new Vector2(move_velocity+dash_velocity, playerbody.velocity.y);
    }
    void Attack()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftControl))
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
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && jump_count > 0)
        {
            playerbody.velocity = new Vector2(move_velocity, jump);
            jump_count--;
        }
    }
    void Dash()
    {
        dash_velocity = 0.0f;
        move_velocity = 0;
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            Debug.Log("is dashing");
            if(!can_dash)
        {
            dash_charge += Time.deltaTime;
        }

        if(dash_charge >= dash_recharge_time)
        {
            can_dash = true;
        }
        if (can_dash)
            {
                dash_velocity = dash_amount;
                dash_charge = 0.0f;
                can_dash = false;
        }
    } 
}
}


