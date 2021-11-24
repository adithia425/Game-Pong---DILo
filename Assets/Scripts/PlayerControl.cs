using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //Tombol Gerakan 
    public KeyCode upButton;
    public KeyCode downButton;

    public int batasGerak = 9;

    public float kecepatanGerak;

    private Rigidbody2D rigid;



    private int skor;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Bikin Template Gerakan Sesuai Klik Tombol
        Vector2 gerakan = rigid.velocity;

        if(Input.GetKey(upButton))
        {
            //Jika Menekan Tombol W
            //Player Naik
            gerakan.y = kecepatanGerak;
        } 
        else if (Input.GetKey(downButton))
        {
            //Jika Menekan Tombol S
            //Player Turun
            gerakan.y = -kecepatanGerak;
        }
        else
        {
            //Player Diam
            gerakan.y = 0;
        }

        //Dimasukin ke Rigid Player
        //Player Gerak Sesuai Klik Tombol
        rigid.velocity = gerakan;


        //Batasi Gerakan Player
        //Agar tidak keluar kamera
        //Pake Kodingan Cepat

        if(transform.position.y >= batasGerak)
        {
            //Jika Posisi Player lebih Besar dari batas
            //Paksa berhenti
            transform.position = new Vector2(transform.position.x,batasGerak);
        }else if (transform.position.y <= (-batasGerak))
        {
            //Jika Posisi Player lebih Kecil dari batas
            //Paksa berhenti
            transform.position = new Vector2(transform.position.x, -batasGerak);
        }

    }



    //Manipulasi Score
    public void tambahSkor()
    {
        //Skor Tambah 1
        skor++;
    }

    public void resetSkor()
    {
        skor = 0;
    }

    public int getSkor()
    {
        return skor;
    }


}
