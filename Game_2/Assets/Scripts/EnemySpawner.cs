using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform EnemySpawnPointLeft;
    [SerializeField] private Transform EnemySpawnPointRight;



public void SpawnEnemy(int roundNumber)
    {
        int enemiesToSpawn = roundNumber + 1;
        
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Transform spawnPoint = GetRandomSpawnPoint();
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }

        Debug.Log("Spawned : " + enemiesToSpawn);

    }

    private Transform GetRandomSpawnPoint()
    {
        int randomSide = Random.Range(0, 2); // 0 or 1

            if(randomSide == 0)
        {
            return EnemySpawnPointLeft;

        }
       
            return EnemySpawnPointRight;
        }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
