using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pipe;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    private Vector3 SpawnPos;
    float yPos;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       yPos = Random.Range(-0.15f, 3.02f);
       SpawnPos = new Vector3(transform.position.x, yPos, transform.position.z);
       if(timeBtwSpawn <= 0)
       {
        Instantiate(pipe, SpawnPos, transform.rotation);
        timeBtwSpawn = startTimeBtwSpawn;
       }
       else
       {
        timeBtwSpawn -= Time.deltaTime;
       }
    }
}
