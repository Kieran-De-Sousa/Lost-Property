using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Pickup(GameObject player)
    {
        //Remove the object so it isn't repeatedly picked up.
        Destroy(gameObject);

        //Track the player.
        this.player = player;

        //Add to inventory
    }

    void Deposit(GameObject lostBox)
    {
        //Add item.
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Pickup(col.gameObject);
        }
        if (col.gameObject.name == "LostAndFoundBox")
        {
            Deposit(col.gameObject);
        }
    }
}
