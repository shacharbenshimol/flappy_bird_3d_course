using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The PipeSpawner class handles the spawning of pipe objects in the game.
public class PipeSpawner : MonoBehaviour
{
    // Public variables for setting spawn behavior in the Unity editor.
    public GameObject pipe; // Prefab for the pipe object to spawn.
    public float startTimeBtwSpawn; // Initial time between spawns.

    // Private variables for internal state.
    private float timeBtwSpawn; // Time remaining until the next spawn.
    private Vector3 spawnPos; // Position where the next pipe will spawn.

    // Start is called before the first frame update.
    void Start()
    {
        // Initialization can go here if needed.
    }

    // Update is called once per frame.
    void Update()
    {
        // Randomly set the y-position within a given range.
        float yPos = Random.Range(-0.15f, 3.02f);

        // Update the spawn position.
        spawnPos = new Vector3(transform.position.x, yPos, transform.position.z);

        // Check if it's time to spawn a new pipe.
        if (timeBtwSpawn <= 0)
        {
            // Spawn a new pipe at the calculated position.
            Instantiate(pipe, spawnPos, transform.rotation);

            // Reset the time between spawns.
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            // Decrement the time until the next spawn.
            timeBtwSpawn -= Time.deltaTime;
        }
    }
}
