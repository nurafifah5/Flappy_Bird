using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpawner : MonoBehaviour
{
    //Global Variable
    [SerializeField] private Bird bird;
    [SerializeField] private Shoot bullet;
    [SerializeField] private Transform BirdLocation;
    [SerializeField] private float spawnInterval = 1;

    private Rigidbody2D rigidBody2d;
    //variabel penampung coroutine yang sedang berjalan
    private Coroutine CR_Spawn;

    // Start is called before the first frame update
    void Start()
    {
        //Mendapatkan komponent ketika game baru berjalan
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //menembakkan bullet jika burung belum mati dan player klik kanan mouse
        if (!bird.IsDead() && Input.GetMouseButtonDown(1))
        {
            //menduplikasi game object bullet dan menempatkan posisinya sama dengan game object
            Shoot newBullet = Instantiate(bullet, transform.position, Quaternion.identity);

            //mengaktifkan game object bullet
            newBullet.gameObject.SetActive(true);
        }
    }
}
