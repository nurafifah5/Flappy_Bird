using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//komponen akan ditambahkan jika tidak ada dan komponen tsb tidak dapat dibuang
[RequireComponent(typeof(BoxCollider2D))]

public class Ground : MonoBehaviour
{
    //Global Variables
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
    [SerializeField] private Transform nextPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //pengecekan jika burung null atau belum mati
        if(bird == null || (bird != null && !bird.IsDead()))
        {
            //membuat pipa bergerak ke kiri dengan kecepatan dari variable speed
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    //method untuk menempatkan game object pada posisi next ground
    public void SetNextGround(GameObject ground)
    {
        //pengecekan Null value
        if(ground != null)
        {
            //menempatkan ground berikutnya pada posisi nextground
            ground.transform.position = nextPos.position;
        }
    }

    //method dipanggil ketika game object bersentuhan dengan game object yang lain
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //membuat burung mati ketika bersentuhan dengan game object ini
        if(bird != null && !bird.IsDead())
        {
            bird.Dead();
            Debug.Log("burung mati karena jatuh");
        }
    }
}
