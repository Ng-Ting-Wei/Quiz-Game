using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float countDown = 0f;
    public int score = 0;
    public float highscoretime;

    public Text scoretxt;
    public Text timetxt;

    public GameObject[] buttons;
    public Text[] buttontxt;

    void Start()
    {
        if(PlayerPrefs.GetInt("CheckDifficulty", 0) == 0)
        {
            countDown = 360f;
        }
        else if (PlayerPrefs.GetInt("CheckDifficulty", 1) == 1)
        {
            countDown = 240f;
        }
        else if (PlayerPrefs.GetInt("CheckDifficulty", 2) == 2)
        {
            countDown = 180f;
        }
    }

    void Update()
    {
        scoretxt.text = score.ToString();
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

    public void Answering(int option)
    {
        PlayerPrefs.SetInt("option",option);
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
