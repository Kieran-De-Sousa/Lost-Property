using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIhp : MonoBehaviour
{
    public GameObject player;
    public int playerHealth;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
