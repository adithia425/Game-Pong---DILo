using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public void timeStop()
    {
        Time.timeScale = 0;
    }
    public void timePlay()
    {
        Time.timeScale = 1;
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
