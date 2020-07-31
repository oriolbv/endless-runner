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

    private Vector3 nextTileLocation;

    private Quaternion nextTileRotation;

    void Start()
    {
        // Set our starting point 
        nextTileLocation = startPoint;
        nextTileRotation = Quaternion.identity;

        for (int i = 0; i < initSpawnNum; ++i)
        {
            SpawnNextTile();
        }
    }

    public void SpawnNextTile()
    {
        var newTile = Instantiate(tile, nextTileLocation, 
                                  nextTileRotation);

        // Set location of the new tile
        var nextTile = newTile.Find("SpawnPoint");
        nextTileLocation = nextTile.position;
        nextTileRotation = nextTile.rotation;
    }
}
