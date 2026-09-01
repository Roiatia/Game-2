using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PackageSpawner : MonoBehaviour
{

    [SerializeField] private GameObject packagePrefab;
    [SerializeField] private Transform[] SpawnPoints;
    [SerializeField] private int PackageToSpawn = 3;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPackages();
    }

    private void SpawnPackages()
    {
        List<Transform> AvailablePoints = new List<Transform>(SpawnPoints);

        for (int i = 0; i <PackageToSpawn; i++)
        {
            if(AvailablePoints.Count == 0)
            {
                return;
            }

            int randomIndex = Random.Range(0, AvailablePoints.Count);
            Transform selectedPoints = AvailablePoints[randomIndex];

            Instantiate(packagePrefab, selectedPoints.position, Quaternion.identity);
            AvailablePoints.RemoveAt(randomIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
