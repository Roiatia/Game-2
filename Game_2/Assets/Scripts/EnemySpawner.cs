using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject regularEnemyPrefab;
    [SerializeField] private GameObject strongEnemyPrefab;

    [SerializeField] private Transform enemySpawnPoint;
    [SerializeField] private Transform bigEnemySpawnPoint;






    public int SpawnEnemy(int roundNumber)
    {
        int enemiesToSpawn = roundNumber + 1;

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemyToSpawn = GetRandomEnemyPrefab(roundNumber);

            Transform spawnPoint;

            if (enemyToSpawn == strongEnemyPrefab)
            {
                spawnPoint = enemySpawnPoint;
            }
            else
            {
                spawnPoint = bigEnemySpawnPoint;
            }

            //Vector3 spawnPosition = spawnPoint.position;

            //if (enemyToSpawn == strongEnemyPrefab)
            //{
            //    spawnPosition.x -= i * 1f;
            //}
            //else
            //{
            //    spawnPosition.x += i * 1f;
            //}

            Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
        }

        Debug.Log("Spawned: " + enemiesToSpawn);

        return enemiesToSpawn;
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

 
}
