using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Point : MonoBehaviour
{
    //global variable
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //melakukan pengecekan burung mati atau tidak
        if (!bird.IsDead())
        {
            //menggerakkan game object kesebelah kiri dengan kecepatan tertentu
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    public void SetSize(float size)
    {
        //mendapatkan komponen BoxCollider2D
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        
        //pengecekan null variable
        if(collider != null)
        {
            //mengubah ukuran collider sesuai dengan parameter
            collider.size = new Vector2(collider.size.x, size);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //mendapatkan komponen bird
        Bird bird = collision.gameObject.GetComponent<Bird>();
        
        //menambahkan score jika burung tidak null dan burung belum mati
        if(bird && !bird.IsDead())
        {
            bird.AddScore(1);
        }
    }
}
