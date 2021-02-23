using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float countDown = 0f;
    public float finaltime;
    public float highscoretime;

    public int score = 0;
    public int ScoreHighscore;

    public Text scoretxt;
    public Text timetxt;

    public GameObject[] buttons;
    public Text[] buttontxt;

    void Start()
    {
        if(PlayerPrefs.HasKey("hc"))
        {
            highscoretime = PlayerPrefs.GetFloat("hc");
        }
        else
        {
            highscoretime = 999;
        }

        if(PlayerPrefs.HasKey("ScoreHighscore"))
        {
            ScoreHighscore = PlayerPrefs.GetInt("ScoreHighscore", 0);
        }

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
        TrackHighscore();

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
        finaltime = countDown;
        if(finaltime > highscoretime)
        {
            PlayerPrefs.SetFloat("hc", finaltime);
        }
        if (countDown < 0)
        {
            countDown = 0f;
            SceneManager.LoadScene("GameLose");
        }
    }

    public void TrackHighscore()
    {
        scoretxt.text = (score).ToString("0");
        ScoreHighscore = score;
        PlayerPrefs.SetInt("ScoreHighscore", ScoreHighscore);
    }
}
