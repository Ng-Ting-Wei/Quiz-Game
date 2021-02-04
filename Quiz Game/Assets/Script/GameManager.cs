using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float countDown = 180f;
    private int score;

    public Text scoretxt;
    public Text timetxt;

    public GameObject[] buttons;
    public Text[] buttontxt;
    private string[] choice;

    private void Update()
    {
        timeCountdown();
        testing();
    }

    private void testing()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            countDown -= 50f;
        }
    }

    private void multipleChoice()
    {
        
    }

    private void timeCountdown()
    {
        countDown -= Time.deltaTime;
        timetxt.text = (countDown).ToString("0");
        if (countDown < 0)
        {
            countDown = 0f;
            SceneManager.LoadScene("GameLose");
        }
    }
}
