using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text displayTime;

    public float timerCounter = 0;
    public float finaltime;

    private float highscoretime;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("hc"))
        {
            highscoretime = PlayerPrefs.GetFloat("hc");
        }
        else
        {
            highscoretime = 999;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timerCounter += Time.deltaTime;
        displayTime.text = timerCounter.ToString("f2");
    }
}
