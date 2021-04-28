using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public GameObject inv;
    GameObject[,] slots;
    
    void Start()
    {
        //inventory = GameObject.Find("Inventory");
        

        GameObject slot_holder = inv.transform.GetChild(2).gameObject;
        
        slots[0, 0] = slot_holder.transform.GetChild(0).gameObject;
        slots[1, 0] = slot_holder.transform.GetChild(1).gameObject;
        slots[2, 0] = slot_holder.transform.GetChild(2).gameObject;
        slots[3, 0] = slot_holder.transform.GetChild(3).gameObject;
        slots[0, 1] = slot_holder.transform.GetChild(4).gameObject;
        slots[1, 1] = slot_holder.transform.GetChild(5).gameObject;
        slots[2, 1] = slot_holder.transform.GetChild(6).gameObject;
        slots[3, 1] = slot_holder.transform.GetChild(7).gameObject;
        slots[0, 2] = slot_holder.transform.GetChild(8).gameObject;
        slots[1, 2] = slot_holder.transform.GetChild(9).gameObject;
        slots[2, 2] = slot_holder.transform.GetChild(10).gameObject;
        slots[3, 2] = slot_holder.transform.GetChild(11).gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
