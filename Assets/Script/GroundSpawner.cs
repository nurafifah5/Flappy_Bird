using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class GroundSpawner : MonoBehaviour
{
    //menampung referensi ground yang ingin dibuat
    [SerializeField] private Ground groundReference;

    //menampung ground sebelumnya
    private Ground previousGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //method membuat Ground game object baru
    private void SpawnGround()
    {
        //pengecekan Null variable
        if(previousGround != null)
        {
            //menduplikasi Groundref
            Ground newGround = Instantiate(groundReference);

            //mengaktifkan game object
            newGround.gameObject.SetActive(true);

            //menempatkan new ground dengan posisi nextground dari previousground agar sejajar dengan ground sebelumnya
            previousGround.SetNextGround(newGround.gameObject);
        }
    }

    //method dipanggil ketika terdapat game object lain yang memiliki komponen collider keluar dari area collider
    private void OnTriggerExit2D(Collider2D collision)
    {
        //mencari komponen ground dari object yang keluar dari area trigger
        Ground ground = collision.GetComponent<Ground>();

        //pengecekan null variable
        if (ground)
        {
            //mengisi variable previousGround
            previousGround = ground;

            //membuat ground baru
            SpawnGround();
        }
    }
}
