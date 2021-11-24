using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GawangControl : MonoBehaviour
{
    public PlayerControl player;

    //Ketika Gawang Terkena Suatu Collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Ball")
        {
            player.tambahSkor();

            PanelGame.instance.calculateScore();
            //Cek Jika Skornya Maximal,
            //Maka Game Berhenti
            if(player.getSkor() >= GameManager.instance.skorTertinggi)
            {
                GameManager.instance.gameSelesai(player.gameObject.name);
            }
            else
            { 
                collision.gameObject.SendMessage("restartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }

}
