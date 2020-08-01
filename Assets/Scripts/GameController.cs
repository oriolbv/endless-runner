using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Tooltip("A reference to the tile we want to spawn")]
    public Transform tile;

    [Tooltip("First tile position")]
    public Vector3 startPoint = new Vector3(0, 0, -5);

    [Tooltip("Number of initialy created tiles")]
    [Range(1, 15)]
    public int initSpawnNum = 10;

    public int initNoObstacles = 4;

    private Vector3 nextTileLocation;

    private Quaternion nextTileRotation;

    void Start()
    {
        // Set our starting point 
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; ++i)
        {
            SpawnNextTile(i >= initNoObstacles);
        }
    }

    public void SpawnNextTile(bool spawnObstacles = true)
    {
        var newTile = Instantiate(tile, nextTileLocation, 
                                  nextTileRotation);

        // Set location of the new tile
        var nextTile = newTile.Find("SpawnPoint");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;
    
        if (!spawnObstacles)
            return;

        // Now we need to get all of the possible places to spawn the obstacle 
        var obstacleSpawnPoints = new List<GameObject>();

        // Go through each of the child game objects in our tile 
        foreach (Transform child in newTile)
        {
            // If it has the ObstacleSpawn tag 
            if (child.CompareTag("ObstacleSpawn"))
            {
                // We add it as a possibilty 
                obstacleSpawnPoints.Add(child.gameObject);
            }
        }

        // Make sure there is at least one 
        if (obstacleSpawnPoints.Count > 0)
        {
            // Get a random object from the ones we have 
            var spawnPoint = obstacleSpawnPoints[Random.Range(0, obstacleSpawnPoints.Count)];

            // Store its position for us to use 
            var spawnPos = spawnPoint.transform.position;

            // Create our obstacle 
            var newObstacle = Instantiate(Obstacle, spawnPos, Quaternion.identity);

            // Have it parented to the tile
            newObstacle.SetParent(spawnPoint.transform);
        }
    }
}
