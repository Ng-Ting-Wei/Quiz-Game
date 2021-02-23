using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    public Text HighscoreText;
    public Text ScoreHighscoreText;

    // Start is called before the first frame update
    void Start()
    {
        HighscoreText.text = PlayerPrefs.GetFloat("hc").ToString("0");
        ScoreHighscoreText.text = PlayerPrefs.GetInt("ScoreHighscore", 0).ToString("0");
    }

    // Update is called once per frame
    void Update()
    {

    }

}
