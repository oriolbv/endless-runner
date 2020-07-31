using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody rb;
    
    [Header("Physics")]
    [Range(0, 10)] 
    public float dodgeSpeed = 5;
    [Range(0, 10)] 
    public float rollSpeed = 5; 

   // Use this for initialization 
   void Start () 
   { 
        // Get access to our Rigidbody component 
        rb = GetComponent<Rigidbody>(); 
   } 

   // Update is called once per frame 
   void Update () 
   { 
        // Check if we're moving to the side 
        var horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed; 
        rb.AddForce(horizontalSpeed, 0, rollSpeed); 
   }
}
