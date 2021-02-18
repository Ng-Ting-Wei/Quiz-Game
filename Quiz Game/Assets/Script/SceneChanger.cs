using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void Loadlevel(string level)
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
        SceneManager.LoadScene("Level1");
    }
}
