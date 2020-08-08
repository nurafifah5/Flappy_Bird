using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    //Global variable
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;

    // Update is called once per frame
    void Update()
    {
        //pengecekan jika burung belum mati
        if (!bird.IsDead())
        {
            //membuat pipa bergerak ke kiri dengan kecepatan tertentu
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    //membuat bird mati ketika bersentuhan dan menjatuhkannya ke ground jika mengenai diatas collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();

        //pengecekan null value
        if (bird)
        {
            //mendapatkan komponen collider pada game object
            Collider2D collider = GetComponent<Collider2D>();

            //melakukan pengecekan null variable atau tidak
            if(collider)
            {
                //menonaktifkan collider
                collider.enabled = false;
            }
            //burung mati
            bird.Dead();
        }
    }
}
