using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private float attack_time;
    public float start_attack_time;
    public Transform attackPos;
    public float attackRange;
    public LayerMask Enemies;
    public int damage;
    private void FixedUpdate()
    {
         if(attack_time <= 0)
        {
            if(Input.GetKey(KeyCode.LeftControl))
            {
                Collider2D[] enemiesDamaged = Physics2D.OverlapCircleAll(attackPos.position, attackRange, Enemies);
                for (int i = 0; i < enemiesDamaged.Length; i++)
                {
                    enemiesDamaged[i].GetComponent<Enemies>().TakeDamage(damage);
                }
            }
            attack_time = start_attack_time;
        } 
        else
        {
            attack_time -= Time.deltaTime;
        }
    }
}
