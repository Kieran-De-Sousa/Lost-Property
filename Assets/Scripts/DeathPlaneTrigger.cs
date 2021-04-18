using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death_Plane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject PlayerCharacter = GameObject.FindGameObjectWithTag("Player");
        Collider2D PlayerCollider = PlayerCharacter.GetComponent<BoxCollider2D>();

        if (other == PlayerCollider)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
