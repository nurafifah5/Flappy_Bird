using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{

    //Global Variables
    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnJump, OnDead;
    [SerializeField] private int score;
    [SerializeField] private UnityEvent OnAddPoint;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text finalScore;

    private Rigidbody2D rigidBody2d;
    private Animator animator;

    //init variable
    void Start()
    {
        //Mendapatkan komponent ketika game baru berjalan
        rigidBody2d = GetComponent<Rigidbody2D>();
        //mendapatkan komponen animator pada game objects
        animator = GetComponent<Animator>();
    }

    //update setiap frame
    void Update()
    {
        //melakukan pengecekan jika bird belum mati dan klik kiri pada mouse
        //Input.GetMouseButton(0) -> bikin burung loncat tiap kali mouse  diklik kiri
        if(!isDead && Input.GetMouseButtonDown(0))  
        {
            //Burung loncat
            Jump();
        }
    }

    //fungsi untuk mengecek sudah mati apa belum
    public bool IsDead()
    {
        return isDead;
    }

    //membuat bird mati
    public void Dead()
    {
        //pengecekan jika belum mati dan value OnDead tidak sama dengan Null
        if(!isDead && OnDead != null)
        {
            //memanggil semua event pada OnDead
            OnDead.Invoke();
        }

        //mengeset variable Dead menjadi true
        isDead = true;
    }

    void Jump()
    {
        //mengecek rigidbody null atau tidak
        if(rigidBody2d)
        {
            //menghentikan kecepatan burung ketika jatuh. kalau dihapus, tinggi loncatan burung tergantung lamanya dia jatuh
            rigidBody2d.velocity = Vector2.zero;
            //menambahkan gaya ke arah sumbu y agar burung lompat
            rigidBody2d.AddForce(new Vector2(0, upForce));
        }

        //pengecekan Null variable
        if(OnJump != null)
        {
            //menjalankan semua event onjump event
            OnJump.Invoke();
        }
    }

    private void OnCollisionEnter2d(Collision2D collision)
    {
        //menghentikan animasi burung ketika bersentuhan dengan objek lain
        animator.enabled = false;
    }

    public void AddScore(int value)
    {
        //menambahkan score value
        score += value;

        //pengecekan null value
        if (OnAddPoint != null)
        {
            //memanggil semua event pada OnAddPoint
            OnAddPoint.Invoke();
        }

        //mengubah nilai text pada score text
        scoreText.text = score.ToString();

        //menampilkan total skor poin
        finalScore.text = score.ToString();
    }
}
