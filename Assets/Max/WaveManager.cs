using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEditor.Experimental.GraphView;

public class WaveManager : MonoBehaviour
{
    public GameObject enemy1;  // Prefab for average zombie
    public GameObject enemy2;  // Prefab for tank zombie
    public GameObject enemy3;  // Prefab for runner zombie

    public Transform[] spawnPoints;
    public TMP_Text WaveText;
    public int startingWave = 1;
    private int currentWave;

    public int zombiesPerWave = 5;
    public float timeBetweenWaves = 10;
    public float spawnRate = 1;


    // Array of spawn points
    public float spawnInterval = 5f; // Time interval between each spawn
    public int spawnCount = 1;       // Number of zombies to spawn in each interval

    private const float SPAWN_DELAY = 1f; // Delay between individual spawns during a wave

    // Start is called before the first frame update
    void Start()
    {
        currentWave = startingWave;
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            StartCoroutine(SpawnWave(currentWave));
            currentWave++;
            int WaveTextNo = currentWave - 1;
            WaveText.text = WaveTextNo.ToString();
        }
    }

    private IEnumerator SpawnWave(int waveNumber)
    {
      
        Debug.Log("WaveNumber is:"+ waveNumber);
        // Increase the number of zombies per wave
        int numberOfZombiesToSpawn = zombiesPerWave + waveNumber * 2;

        for (int i = 0; i < numberOfZombiesToSpawn; i++)
        {
            SpawnRandomZombie();
            yield return new WaitForSeconds(spawnRate);
        }
        Debug.Log("End of wave");
    }
    private void SpawnRandomZombie()
    {
        Debug.Log("zombie spawned");
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Randomly choose which type of zombie to spawn
        int randomZombieType = Random.Range(1, 4);
        GameObject zombieToSpawn = null;
        Transform PlayerTransform = GameObject.FindWithTag("Player").transform; // finds player's co-ordinates

        switch (randomZombieType)
        {
            case 1:
                zombieToSpawn = enemy1; // Average zombie
               
                break;
            case 2:
                zombieToSpawn = enemy2; // Tank zombie
                break;
            case 3:
                zombieToSpawn = enemy3; // Runner zombie
                break;
        }
        Vector3 PlayerDiraction = PlayerTransform.position - spawnPoint.position; // sets the zombies unique spawn rotation

        Quaternion FixedRotation = Quaternion.LookRotation(PlayerDiraction); // when the roation is instatied it will use the roation that is facing the player

        Instantiate(zombieToSpawn, spawnPoint.position, FixedRotation);
    }

    
}
