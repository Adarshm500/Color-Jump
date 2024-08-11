using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;

    [SerializeField] private int numberOfPlatforms;
    [SerializeField] private float levelWidth = 3f;
    [SerializeField] private float minY = .2f;
    [SerializeField] private float maxY = 1.5f;

    private Vector3 spawnPosition = new Vector3();
    private float upmostPlatformPosition;
    private Camera mainCamera;
    private float platformGenerateBuffer = 1f;

    private void Start() 
    {
        mainCamera = Camera.main;
        SpawnPlatforms();
    }

    private void Update() 
    {
        if (mainCamera.transform.position.y +  mainCamera.orthographicSize + platformGenerateBuffer > upmostPlatformPosition)
        {
            SpawnPlatforms();
        }
    }

    private void SpawnPlatforms()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
            upmostPlatformPosition = spawnPosition.y;
        }
    }
}
