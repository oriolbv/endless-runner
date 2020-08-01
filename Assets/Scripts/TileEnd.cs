using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEnd : MonoBehaviour
{
    public float destroyTime = 1.5f; 

    void OnTriggerEnter(Collider col) 
    { 
        // Check collision with Player
        if (col.gameObject.GetComponent<Player>()) 
        { 
            // Spawn new tile
            GameObject.FindObjectOfType<GameController>().SpawnNextTile(); 

            // Destroy current tile after destroyTime
            Destroy(transform.parent.gameObject, destroyTime); 
        } 
    } 
}
