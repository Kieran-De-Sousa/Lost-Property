using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public LayerMask groundlayer;
    public bool isGrounded = false;
    public Transform groundcheck;
    public bool facingRight = true;
    public float speed;
    public float move_velocity;
    public float dash_velocity;
    public float jump_amount;
    public Animator animator;
    private Rigidbody2D playerbody;
    public BoxCollider2D playercollider;
    public bool isAttacking = false;
    public int lifePoints;
    private float jump_held_time;
    public float dash_amount;
    public float dash_recharge_time;
    private float dash_charge;
    private bool can_dash = false;

    // Start is called before the first frame update
    void Start()
    {
        playercollider = this.gameObject.GetComponent<BoxCollider2D>();
        playerbody = this.gameObject.GetComponent<Rigidbody2D>();
        dash_charge = 0.0f;
        dash_velocity = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isAttacking", isAttacking);
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, 0.2f, groundlayer);
        animator.SetFloat("Speed", Mathf.Abs(move_velocity+dash_velocity));
        animator.SetFloat("Jump_speed", Mathf.Abs(playerbody.velocity.y));

        float h = Input.GetAxis("Horizontal");

        if (h > 0 && !facingRight)
        {
            Flip();
        }
        else
        {
            if (h < 0 && facingRight)
            {
                Flip();
            }
        }

        dash_velocity = 0.0f;
        move_velocity = 0;

        if (!isGrounded)
        {
            jump_held_time = 0;
        }


        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isGrounded == true)
        {
            jump_held_time += 0.01f;
            if(jump_held_time >= 1.0f)
            {
                jump_held_time = 1.0f;
                
            }
            Debug.Log(jump_held_time);
        }

        if ((Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)) && isGrounded == true)
        {
            playerbody.velocity = new Vector2(move_velocity, jump_amount*jump_held_time);
            jump_held_time = 0.0f;
        }

       


        //dash_velocity = 0;

        if(!can_dash)
        {
            dash_charge += Time.deltaTime;
        }

        if(dash_charge >= dash_recharge_time)
        {
            can_dash = true;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            move_velocity -= speed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            move_velocity += speed;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (can_dash)
            {
                dash_velocity = dash_amount;
                dash_charge = 0.0f;
                can_dash = false;
                playerbody.AddForce(new Vector2(dash_amount * transform.localScale.x, 0));
            }
        }
        

        playerbody.velocity = new Vector2(move_velocity, playerbody.velocity.y);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isAttacking = true;
        }
        else if (!Input.GetKey(KeyCode.LeftControl))
        {
            isAttacking = false;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

