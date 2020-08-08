using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    //Global Variable
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp, pipeDown;
    [SerializeField] private float spawnInterval = 1;
    [SerializeField] public float holeSize;
    [SerializeField] private float maxMinOffset = 1;
    [SerializeField] private Point point;
    
    //variabel penampung coroutine yang sedang berjalan
    private Coroutine CR_Spawn;

    // Start is called before the first frame update
    void Start()
    {
        //memulai spawn pipe
        StartSpawn();
        
    }

    // Update is called once per frame
    void Update()
    {
        //mengubah size holesize menjadi random
        holeSize = Random.Range(0.0f, 3.0f);
    }

    void StartSpawn()
    {
        //menjalankan fungsi coroutine IeSpawn()
        if(CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        //menghentikan Coroutine IeSpawn jika sebelumnya telah dijalankan
        if(CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        //menduplikasi game object pipeUp dan menempatkan posisinya sama dengan game object ini tetapi dirotasi 180 derajat
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0, 0, 180));

        //mengaktifkan game objek newPipeUp
        newPipeUp.gameObject.SetActive(true);

        //menduplikasi game object pipeDown dan menempatkan posisinya sama dengan game object
        Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);

        //mengaktifkan game object newPipeDown
        newPipeDown.gameObject.SetActive(true);

        //menempatkan posisi dari pipa yang sudah terbentuk agar memiliki lubang di tengahnya
        newPipeUp.transform.position += Vector3.up * (holeSize / 2);
        newPipeDown.transform.position += Vector3.down * (holeSize / 2);

        //menyesuaikan posisi pipa yang sudah dibentuk dengan fungsi sin
        float y = maxMinOffset * Mathf.Sin(Time.time);
        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;

        //instansiasi poin baru yang didapatkan
        Point newPoint = Instantiate(point, transform.position, Quaternion.identity);

        //membuat poin baru bisa didapatkan jika bird melewati hole diantara pipa
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(holeSize);
        newPoint.transform.position += Vector3.up * y;
    }

    IEnumerator IeSpawn()
    {
        while (true)
        {
            //jika burung mati maka menghentikan pembuatan pipa baru
            if (bird.IsDead())
            {
                StopSpawn();
            }

            //membuat pipa baru
            SpawnPipe();

            //menunggu beberapa detik sesuai spawn interaval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
}
