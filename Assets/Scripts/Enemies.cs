﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    //base class so it can be inherited from other scripts

    int moveSpeed;
    int attackDamage;
    public int lifePoints;
    float attackRadius;
    public float delay;
    public GameObject drop;
    bool can_drop = true;

    //movement
    float followRadius;

    public void setMoveSpeed(int speed)
    {
        moveSpeed = speed;
    }

    public void setAttackDamage(int attdmg)
    {
        attackDamage = attdmg;
    }

    public void setLifePoints(int lp)
    {
        lifePoints = lp;
    }

    public int getMoveSpeed()
    {
        return moveSpeed;
    }

    public int getAttackDamage()
    {
        return attackDamage;
    }

    public int getLifePoints()
    {
        return lifePoints;
    }


    //movement toward a player
    public void setFollowRadius(float r)
    {
        followRadius = r;
    }
    //attack radius 
    public void setAttackRadius(float r)
    {
        attackRadius = r;
    }

    //if player in radius move toward him 
    public bool checkFollowRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < followRadius)
        {
            //player in range
            return true;
        }
        else
        {
            return false;
        }
    }

    //if player in radius attack him
    public bool checkAttackRadius(float playerPosition, float enemyPosition)
    {
        if (Mathf.Abs(playerPosition - enemyPosition) < attackRadius)
        {
            //in range for attack
            return true;
        }
        else
        {
            return false;
        }
    }
    public void TakeDamage(int damage)
    {
        lifePoints -= damage;
        Debug.Log("Damage Taken!");
    }
    private void FixedUpdate()
    {
        if (lifePoints <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        print("isdead");
        this.GetComponent<Animator>().SetBool("isDead", true);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);

        if (can_drop)
        {
            //Get position of the current bad guy.
            //Vector2 position = this.GetComponent<Rigidbody2D>().position;
           // Instantiate(drop, new Vector3(position.x, position.y, 0), Quaternion.identity);
           // can_drop = false;
        }
    }
}