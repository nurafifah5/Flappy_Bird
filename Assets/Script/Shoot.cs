using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]

public class Shoot : MonoBehaviour
{
    //Global variable
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipe;
    [SerializeField] private Shoot bullet;
    [SerializeField] private Transform BirdLocation;
    [SerializeField] private Point point;
    private float bulletSpeed = 2;
    private Rigidbody2D rigidBody2d;

    //init variable
    void Start()
    {
        //Mendapatkan komponent ketika game baru berjalan
        rigidBody2d = GetComponent<Rigidbody2D>();

        //membuat posisi keluar bullet mengikuti posisi bird
        transform.position = new Vector3((BirdLocation.position.x + 1), BirdLocation.position.y, BirdLocation.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        //pengecekan jika burung belum mati
        if (!bird.IsDead())
        {
            //membuat shoot bergerak ke kanan dengan kecepatan tertentu
            transform.Translate(Vector3.right * bulletSpeed * Time.deltaTime, Space.World);
        }
    }

    //membuat pipa hancur ketika bersentuhan
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Pipe pipe = collision.gameObject.GetComponent<Pipe>();
        Point point = collision.gameObject.GetComponent<Point>();

        //pengecekan apakah bullet null
        if (pipe)
        {
            //mendapatkan komponen game object bullet
            Collider2D collider = GetComponent<Collider2D>();

            //melakukan pengecekan null variable atau tidak
            if (collider)
            {
                //menghancurkan diri sendiri
                Destroy(collider.gameObject);
                //menghancurkan pipa
                Destroy(pipe.gameObject);
                //menghancurkan poin?
                Destroy(point.gameObject);
            }
        }
    }

}
