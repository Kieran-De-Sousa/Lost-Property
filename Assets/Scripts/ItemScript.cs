using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public GameObject inventory;
    GameObject slot_holder;
    GameObject[,] slots;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            //Add to inventory.
            //Destroy(this);
            //GameObject button = slots[0,0].transform.GetChild(0).gameObject;
            //GameObject icon = button.transform.GetChild(0).gameObject;

            //icon.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
            //icon.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        }
    }
}
