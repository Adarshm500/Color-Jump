using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject gemPrefab;
    [SerializeField] private int numberOfPlatforms;
    [SerializeField] private float levelWidth = 3f;
    private float minY = .3f;
    private float maxY = 1.5f;


    private Vector3 spawnPosition = new Vector3();
    private Vector3 gemSpawnPosition = new Vector3();
    private float upmostPlatformPosition;
    private Camera mainCamera;
    private float platformGenerateBuffer = 1f;

    // maximum distance possible in between the platform for player to be able to progress the level
    private float maxDifficultyLowerLimit;
    private float maxDifficultyUpperLimit;
    private void Start() 
    {
        maxDifficultyLowerLimit = 3f;
        maxDifficultyUpperLimit = 3.2f;
        mainCamera = Camera.main;
        SpawnPlatforms();
    }

    private void Update() 
    {
        if (mainCamera.transform.position.y +  mainCamera.orthographicSize + platformGenerateBuffer > upmostPlatformPosition)
        {
            if (maxY < maxDifficultyUpperLimit)
            {
                maxY = Mathf.Min(maxY + 0.5f, maxDifficultyUpperLimit);
            }

            if (minY < maxDifficultyLowerLimit)
            {
                minY = Mathf.Min(minY + 0.3f, 
                maxDifficultyLowerLimit);
            }

            SpawnPlatforms();
        }
    }

    private void SpawnPlatforms()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += UnityEngine.Random.Range(minY, maxY);
            spawnPosition.x = UnityEngine.Random.Range(-levelWidth, levelWidth);

            if (UnityEngine.Random.Range(1,15) == 1)
            {
                gemSpawnPosition = spawnPosition + new Vector3(0f, 0.6f, 0f);
                Instantiate(gemPrefab, gemSpawnPosition, Quaternion.identity);
            }

            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            upmostPlatformPosition = spawnPosition.y;
        }
    }
}
