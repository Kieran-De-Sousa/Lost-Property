using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private float attack_time;
    public float attack_start;
    public Transform attackPos;
    public LayerMask enemies;
    public float attackrange;
    public int damage;

    private void FixedUpdate()
    {
        if(attack_time <= 0)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                Collider2D[] damageenemies = Physics2D.OverlapCircleAll(attackPos.position, attackrange, enemies);
                for (int i = 0; i < damageenemies.Length; i++)
                {
                    damageenemies[i].GetComponent<Enemies>().TakeDamage(damage);
                }
            }
            attack_time = attack_start;
        }
        else
        {
            attack_time -= Time.deltaTime;
        }

    } 

}
