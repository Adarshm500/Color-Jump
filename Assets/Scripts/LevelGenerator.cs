using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject standardPlatformPrefab;
    [SerializeField] private GameObject oneTimeJumpPlatformPrefab;
    [SerializeField] private GameObject superJumpPlatformPrefab;
    [SerializeField] private GameObject gemPrefab;

    [SerializeField] private int numberOfPlatforms;
    [SerializeField] private float levelWidth = 3f;

    private float minY = 0.5f;
    private float maxY = 1.5f;

    private Vector3 spawnPosition = new Vector3();
    private Vector3 gemSpawnPosition = new Vector3();

    private Camera mainCamera;
    private float upmostPlatformPosition;
    private float platformGenerateBuffer = 1f;

    // Difficulty Settings
    private float maxDifficultyLowerLimit;
    private float maxDifficultyUpperLimit;

    // Platform spawn probabilities (adjustable via Inspector)
    [SerializeField][Range(0, 100)] private float oneTimeJumpProbability = 0.4f;
    [SerializeField][Range(0, 100)] private float superJumpProbability = 0.4f;
    [SerializeField][Range(0, 100)] private float gemSpawnProbability = 1f;

    private int gemProbabilityUpperLimit = 8;
    private int oneTimeJumpProbabilityUpperLimit = 8;
    private int superJumpProbabilityUpperLimit = 8;

    private float cameraSpeedUpperLimit = 3f;
   private void Awake()
   {
        maxDifficultyLowerLimit = 2.25f;
        maxDifficultyUpperLimit = 4.5f;
        mainCamera = Camera.main;
   }

    private void Start() 
    {
        SpawnPlatforms();
    }

    private void Update() 
    {

        if (mainCamera.transform.position.y +  mainCamera.orthographicSize + platformGenerateBuffer > upmostPlatformPosition)
        {
            AdjustDifficulty();
            SpawnPlatforms();
        }
    }

    private void AdjustDifficulty()
    {
        // Encapsulated difficulty adjustment logic
        maxY = Mathf.Min(maxY + 0.225f, maxDifficultyUpperLimit);
        minY = Mathf.Min(minY + 0.1125f, maxDifficultyLowerLimit);
        oneTimeJumpProbability = Mathf.Min(oneTimeJumpProbability * 2f, oneTimeJumpProbabilityUpperLimit);
        superJumpProbability = Mathf.Min(superJumpProbability * 2f, superJumpProbabilityUpperLimit);
        gemSpawnProbability = Mathf.Min(gemSpawnProbability * 2f, gemProbabilityUpperLimit);


        CameraController.instance.cameraSpeed = Mathf.Min(CameraController.instance.cameraSpeed * 1.12f, cameraSpeedUpperLimit);
        Debug.Log("CameraSpeed = " + CameraController.instance.cameraSpeed);
    }

    private void SpawnPlatforms()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += UnityEngine.Random.Range(minY, maxY);
            spawnPosition.x = UnityEngine.Random.Range(-levelWidth, levelWidth);

            // Spawn gem with configured probability
            if (UnityEngine.Random.Range(1, 101) <= gemSpawnProbability)
            {
                gemSpawnPosition = spawnPosition + new Vector3(0f, 0.6f, 0f);
                Instantiate(gemPrefab, gemSpawnPosition, Quaternion.identity);
            }

            // Weighted random platform spawning
            int platformChoice = UnityEngine.Random.Range(1, 101);
            if (platformChoice <= oneTimeJumpProbability)
            {
                Instantiate(oneTimeJumpPlatformPrefab, spawnPosition, Quaternion.identity);
            }
            else if (platformChoice <= oneTimeJumpProbability + superJumpProbability)
            {
                Instantiate(superJumpPlatformPrefab, spawnPosition, Quaternion.identity);
            }
            else
            {
                Instantiate(standardPlatformPrefab, spawnPosition, Quaternion.identity);
            }
            upmostPlatformPosition = spawnPosition.y;

            if (gemSpawnPosition.y > spawnPosition.y)
            {
                // gem has been spawned
                spawnPosition.y += 1f;
            }
        }
    }
}
