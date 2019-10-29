using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders_Exercise_2 : MonoBehaviour
{
    public float force;

    // Detects the frame whenever an object starts colliding with the object to which this script is attached to
    // the argument "collision" represents information about the collision event
    // - THE OBJECT THAT COLLIDES NEES TO HAVE A COLLIDER
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // if the object collided with is an "Obstacle" then we make that collided object jump
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }
}
