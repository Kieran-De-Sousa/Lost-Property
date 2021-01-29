using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public float speed;
    public float move_velocity;
    public float jump;
    private Rigidbody2D playerbody;
 
    // Start is called before the first frame update
    void Start()
    {
        playerbody = this.gameObject.GetComponent<Rigidbody2D>();
    }
    bool is_grounded = true;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if(is_grounded)
            {
                playerbody.velocity = new Vector2(playerbody.velocity.x, jump);
                is_grounded = false;
            }
        }
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(CollisionIsWithGround(collision))
        {
            is_grounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(!CollisionIsWithGround(collision))
        {
            is_grounded = false;
        }
    }
    private bool CollisionIsWithGround(Collision2D collision)
    {
        bool is_with_ground = false;
        foreach(ContactPoint2D c in collision.contacts)
        {
            Vector2 collision_direction_vector = c.point - playerbody.position;
            if(collision_direction_vector.y < 0)
            {
                is_with_ground = true;
            }
        }
        return is_with_ground;
    }
}
