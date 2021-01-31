using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startTime = 10f;

    public Text Countdown_Text;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1;
        Countdown_Text.text = currentTime.ToString ("0");

        if(currentTime <= 0)
        {
            currentTime = 0;
        }

    }
}
