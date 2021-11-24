using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int skorTertinggi;

    public GameObject panelFinish;
    public Text textWinner;

    //instance = Script Game Manager
    private void Awake()
    {
        instance = this;
    }

    public void gameMulai()
    {
        PanelGame.instance.p1.resetSkor();
        PanelGame.instance.p2.resetSkor();
        PanelGame.instance.calculateScore();
        BallControl.instance.restartGame();
    }
    public void gameSelesai(string player)
    {
        panelFinish.SetActive(true);
        textWinner.text = player + "\nWinner";
        Time.timeScale = 0;
    }



}
