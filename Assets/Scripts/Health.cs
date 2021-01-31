using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int delay;
    public int health;
    public int maxHealth;

    public Image[] hearts;
    public Sprite fullheart;
    public Sprite noheart;

    private void FixedUpdate()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        if(health <= 0)
        {
            Death();
        }
        
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullheart;
            }
            else
            {
                hearts[i].sprite = noheart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Damage Taken!");
    }
    public void Death()
    {
        this.GetComponent<Animator>().SetBool("isDead", true);
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
        StartCoroutine(wait());
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public IEnumerator wait()
    {
        yield return new WaitForSeconds(2f);
    }
}
