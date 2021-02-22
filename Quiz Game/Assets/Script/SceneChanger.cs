using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    void Start()
    {

    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Level1()
    {
        PlayerPrefs.SetInt("CheckDifficulty", 0);
        SceneManager.LoadScene("Level1");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("Level Selection");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void Level2()
    {
        PlayerPrefs.SetInt("CheckDifficulty", 1);
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        PlayerPrefs.SetInt("CheckDifficulty", 2);
        SceneManager.LoadScene("Level3");
    }

}
