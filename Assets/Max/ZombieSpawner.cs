using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject enemy1;  // Prefab for average zombie
    public GameObject enemy2;  // Prefab for tank zombie
    public GameObject enemy3;  // Prefab for runner zombie

    public Transform[] spawnPoints;  // Array of spawn points
    public float spawnInterval = 5f; // Time interval between each spawn
    public int spawnCount = 3;       // Number of zombies to spawn in each interval

    private const float SPAWN_DELAY = 1f; // Delay between individual spawns during a wave

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    // Coroutine to spawn waves of zombies
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // Spawn a set number of zombies at random intervals
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnRandomZombie();
                yield return new WaitForSeconds(SPAWN_DELAY); // Wait between individual spawns
            }

            // Wait for the defined interval before starting the next wave
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Spawns a random zombie type at a random spawn point
    private void SpawnRandomZombie()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("No spawn points defined!");
            return;
        }

        // Choose a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Choose a random zombie type
        GameObject zombieToSpawn = GetRandomZombie();

        // Instantiate the selected zombie at the chosen spawn point
        if (zombieToSpawn != null)
        {
            Instantiate(zombieToSpawn, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Zombie prefab not assigned!");
        }
    }

    // Returns a random zombie prefab
    private GameObject GetRandomZombie()
    {
        int randomZombieIndex = Random.Range(1, 4); // Randomly choose between 1, 2, or 3
        switch (randomZombieIndex)
        {
            case 1:
                return enemy1; // Average zombie
            case 2:
                return enemy2; // Tank zombie
            case 3:
                return enemy3; // Runner zombie
            default:
                return null;
        }
    }
}
