using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : Enemies
{

    //variables
    public float timebtwattack;
    public float attackTime;
    public int _moveSpeed;
    public int _attackDamage;
    public float _attackRadius;
    public Transform attackPos;
    public float attackrange;
    public LayerMask player;
    public int damage;
    public bool facingRight;
    private float firstDelta;
    private float secondDelta;

    //movement
    public float _followRadius;
    //end
    [SerializeField] Transform playerTransform;
    [SerializeField] Animator enemyAnim;
    SpriteRenderer enemySR;

    void Start()
    {
        //get the player transform   
       // playerTransform = FindObjectOfType<>().GetComponent<Transform>();
        //enemy animation and sprite renderer 
        enemyAnim = gameObject.GetComponent<Animator>();
        enemySR = GetComponent<SpriteRenderer>();
        //set the variables
        setMoveSpeed(_moveSpeed);
        setAttackDamage(_attackDamage);
        setAttackRadius(_attackRadius);
        setFollowRadius(_followRadius);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (lifePoints <= 0)
        {
            Death();
        }
        if (checkFollowRadius(playerTransform.position.x, transform.position.x))
        {
            //if player in front of the enemies
            if (playerTransform.position.x < transform.position.x)
            {
                if(facingRight)
                {
                    Flip();
                }
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    enemyAnim.SetBool("isRunning", false);
                    enemyAnim.SetBool("isAttacking", true);
                    if (attackTime <= 0)
                    {
                        Collider2D[] damageenemies = Physics2D.OverlapCircleAll(attackPos.position, attackrange, player);
                        for (int i = 0; i < damageenemies.Length; i++)
                        {
                            damageenemies[i].GetComponent<Health>().TakeDamage(damage);
                        }
                        attackTime = timebtwattack;
                    }
                    else
                    {
                        attackTime -= Time.deltaTime;
                    }
                }
                else
                {
                    this.transform.position += new Vector3(-getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    //for attack animation
                    enemyAnim.SetBool("isAttacking", false);
                    //walk
                    enemyAnim.SetBool("isRunning", true);
                }

            }
            //if player is behind enemies
            else if (playerTransform.position.x > transform.position.x)
            {
                if(!facingRight)
                {
                    Flip();
                }
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    enemyAnim.SetBool("isRunning", false);
                    enemyAnim.SetBool("isAttacking", true);
                    if (attackTime <= 0)
                    {
                        Collider2D[] damageenemies = Physics2D.OverlapCircleAll(attackPos.position, attackrange, player);
                        for (int i = 0; i < damageenemies.Length; i++)
                        {
                            damageenemies[i].GetComponent<Health>().TakeDamage(damage);
                        }
                        attackTime = timebtwattack;
                    }
                    else
                    {
                        attackTime -= Time.deltaTime;
                    }
                }
                else
                {
                    this.transform.position += new Vector3(getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    //for attack animation
                    enemyAnim.SetBool("isAttacking", false);
                    //walk
                    enemyAnim.SetBool("isRunning", true);
                }
            }
        }
        else
        {
            enemyAnim.SetBool("isRunning", false);
            enemyAnim.SetBool("isAttacking", false);
        }

    }
    public void Death()
    {
        this.GetComponent<Animator>().SetBool("isDead", true);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
        void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

