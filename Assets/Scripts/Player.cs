using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> 
/// Responsible for moving the player automatically and  
/// reciving input. 
/// </summary> 
[RequireComponent(typeof(Rigidbody))] 
public class Player : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody rb;
    
    [Header("Physics")]
    [Tooltip("How fast the ball moves left/right")] 
    [Range(0, 10)] 
    public float dodgeSpeed = 5;
    [Tooltip("How fast the ball moves forwards automatically")] 
    [Range(0, 10)] 
    public float rollSpeed = 5; 

   // Use this for initialization 
   void Start () 
   { 
        // Get access to our Rigidbody component 
        rb = GetComponent<Rigidbody>(); 
   }

    void Update()
    {
        
        // Check if game is paused
        if (PauseMenu.paused)
            return;

        // Movement in the x axis 
        float horizontalSpeed = 0;

        // Check if we are running either in the Unity editor or in a standalone build. 
#if UNITY_STANDALONE || UNITY_WEBPLAYER

    // Check if we're moving to the side 
    horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed; 

    // If the mouse is held down (or the screen is tapped on Mobile) 
    if (Input.GetMouseButton(0)) 
    { 
        horizontalSpeed = CalculateMovement(Input.mousePosition); 
    } 

    //Check if we are running on a mobile device 
#elif UNITY_IOS || UNITY_ANDROID

        //Check if Input has registered more than zero touches 
        if (Input.touchCount > 0)
        {
            //Store the first touch detected. 
            Touch myTouch = Input.touches[0];
            horizontalSpeed = CalculateMovement(myTouch.position);

        }

#endif

        // Apply our auto-moving and movement forces 
        var movementForce = new Vector3(horizontalSpeed, 0, rollSpeed); 
 
        // Time.deltaTime is the amount of time since the last frame (approx. 1/60 seconds) 
        movementForce *= (Time.deltaTime * 60); 
 
        // Apply our auto-moving and movement forces 
        rb.AddForce(movementForce); 
    }

    /// <summary> 
    /// Will figure out where to move the player horizontally 
    /// </summary> 
    /// <param name="pixelPos">The position the player has touched/clicked on</param> 
    /// <returns>The direction to move in the x axis</returns> 
    float CalculateMovement(Vector3 pixelPos)
    {
        // Converts to a 0 to 1 scale 
        var worldPos = Camera.main.ScreenToViewportPoint(pixelPos);

        float xMove = 0;

        // If we press the right side of the screen 
        if (worldPos.x < 0.5f)
        {
            xMove = -1;
        }
        else
        {
            // Otherwise we're on the left 
            xMove = 1;
        }

        // Replace horizontalSpeed value
        return xMove * dodgeSpeed;
    }
}
