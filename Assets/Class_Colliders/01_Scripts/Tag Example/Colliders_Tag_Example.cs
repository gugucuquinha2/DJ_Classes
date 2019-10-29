using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders_Tag_Example : MonoBehaviour
{
    // Detects the frame whenever an object starts colliding with the object to which this script is attached to
    // the argument "collision" represents information about the collision event
    // - THE OBJECT THAT COLLIDES NEES TO HAVE A COLLIDER
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // only detects collision, if the gameObject has the corresponding tag
            Debug.Log("Started colliding with: " + collision.gameObject);
        }
    }

    // Detects the frame whenever an object stops colliding with the object to which this script is attached to
    // the argument "collision" represents information about the collision event
    // - THE OBJECT THAT COLLIDES NEES TO HAVE A COLLIDER
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // detects any collision with any gameObject, as long as it has a collider
            Debug.Log("Stopped colliding with: " + collision.gameObject);
        }
    }

    // Detects every frame that the object to which this script is attached remains inside the trigger collider ("other")
    // the argument "other" represents the collider (set as trigger) that collided
    // - THE OBJECT THAT COLLIDES NEES TO HAVE A COLLIDER SET AS A TRIGGER
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            // detects any collision with any gameObject, as long as it has a collider
            Debug.Log("Inside trigger: " + other.gameObject);
        }
    }
}
