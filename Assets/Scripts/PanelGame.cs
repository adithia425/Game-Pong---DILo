using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelGame : MonoBehaviour
{
    public static PanelGame instance; 
    //Bukan Cara Recomended

    public PlayerControl p1;
    public PlayerControl p2;

    public Text textScore1;
    public Text textScore2;

    int score1;
    int score2;

    private void Awake()
    {
        instance = this;
    }
    void Update()
    {
        textScore1.text = "" + score1;
        textScore2.text = "" + score2;
    }

    public void calculateScore()
    {
        score1 = p1.getSkor();
        score2 = p2.getSkor();
    }
}
