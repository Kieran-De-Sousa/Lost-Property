using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : Enemies
{

    //variables
    public int _moveSpeed;
    public int _attackDamage;
    public float _attackRadius;

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
        if (checkFollowRadius(playerTransform.position.x, transform.position.x))
        {
            //if player in front of the enemies
            if (playerTransform.position.x < transform.position.x)
            {

                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    enemyAnim.SetBool("isRunning", false);
                    enemyAnim.SetBool("isAttacking", true);
                }
                else
                {
                    this.transform.position += new Vector3(-getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    //for attack animation
                    enemyAnim.SetBool("isAttacking", false);
                    //walk
                    enemyAnim.SetBool("isRunning", true);
                    enemySR.flipX = false;
                }

            }
            //if player is behind enemies
            else if (playerTransform.position.x > transform.position.x)
            {
                if (checkAttackRadius(playerTransform.position.x, transform.position.x))
                {
                    //for attack animation
                    enemyAnim.SetBool("isRunning", false);
                    enemyAnim.SetBool("isAttacking", true);
                }
                else
                {
                    this.transform.position += new Vector3(getMoveSpeed() * Time.deltaTime, 0f, 0f);
                    //for attack animation
                    enemyAnim.SetBool("isAttacking", false);
                    //walk
                    enemyAnim.SetBool("isRunning", true);
                    enemySR.flipX = true;
                }


            }
        }
        else
        {
            enemyAnim.SetBool("isRunning", false);
            enemyAnim.SetBool("isAttacking", false);
        }


    }
}
