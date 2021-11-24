using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public static BallControl instance;

    // Rigidbody 2D bola
    private Rigidbody2D rigid;
    public float kecepatanBola;

    // Besarnya gaya awal yang diberikan untuk mendorong bola
    public float xGerakAwal;
    public float yGerakAwal;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Time.timeScale = 0;
        rigid = GetComponent<Rigidbody2D>();
    }


    void resetBola()
    {
        transform.position = Vector2.zero;

        rigid.velocity = Vector2.zero;
    }

    void PushBall()
    {
        // Nilai Y sebarapa tinggi di Random
        float besaranY = Random.Range(-yGerakAwal, yGerakAwal);

        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float kiriAtauKanan = Random.Range(0, 2);

        // Jika nilainya di bawah 1, bola bergerak ke kiri. 
        // Jika tidak, bola bergerak ke kanan.
        if (kiriAtauKanan < 1.0f)
        {
            // Gunakan gaya untuk menggerakkan bola ini.
            rigid.AddForce(new Vector2(-xGerakAwal, besaranY));
        }
        else
        {
            rigid.AddForce(new Vector2(xGerakAwal, besaranY));
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Setiap Benturan, Tambah Kecepatan Bola
        rigid.velocity *= 1.1f;

        if(collision.gameObject.tag == "Player")
        {
            float sudut = (transform.position.y - collision.transform.position.y) * 100;

            if(transform.position.x <= collision.transform.position.x)
                rigid.AddForce(new Vector2(- rigid.velocity.x, sudut));
            else
                rigid.AddForce(new Vector2(rigid.velocity.x, sudut));
        }
    }

    public void restartGame()
    {
        resetBola();

        //Tunggu 2 Detik, Lalu mulai lagi
        Invoke(nameof(PushBall), 2);
    }
}
