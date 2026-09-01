using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject regularEnemyPrefab;
    [SerializeField] private GameObject strongEnemyPrefab;
    [SerializeField] private Transform enemySpawnPointLeft;
    [SerializeField] private Transform enemySpawnPointRight;

    public void SpawnEnemy(int roundNumber)
    {
        int enemiesToSpawn = roundNumber + 1;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Transform spawnPoint = GetRandomSpawnPoint();
            GameObject enemyToSpawn = GetRandomEnemyPrefab(roundNumber);

            Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
        }

        Debug.Log("Spawned: " + enemiesToSpawn);
    }

    private Transform GetRandomSpawnPoint()
    {
        int randomSide = Random.Range(0, 2);

        if (randomSide == 0)
        {
            return enemySpawnPointLeft;
        }

        return enemySpawnPointRight;
    }

    private GameObject GetRandomEnemyPrefab(int roundNumber)
    {
        int strongEnemyChance = 20 + roundNumber * 5;
        int randomValue = Random.Range(0, 100);

        if (randomValue < strongEnemyChance)
        {
            return strongEnemyPrefab;
        }

        return regularEnemyPrefab;
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
