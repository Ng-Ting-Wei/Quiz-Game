using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public bool Easy;
    public bool Normal;
    public bool Hard;

    void Start()
    {
        Easy = false;
        Normal = false;
        Hard = false;
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
        Easy = true;
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
        Normal = true;
        SceneManager.LoadScene("Level2");
    }

    public void Level3()
    {
        Hard = true;
        SceneManager.LoadScene("Level3");
    }

}
