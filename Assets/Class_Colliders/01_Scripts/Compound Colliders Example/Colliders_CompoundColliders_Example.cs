using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders_CompoundColliders_Example : MonoBehaviour
{
    // Detects the frame whenever an object starts colliding with the object to which this script is attached to
    // the argument "collision" represents information about the collision event
    // - THE OBJECT THAT COLLIDES NEES TO HAVE A COLLIDER

    // since this is a compound collider, even if this script is only on the parent/main object its children still detect collisions
    // all colliders of the compound work as one (the parent must have a Rigidbody, for it to work) 
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
    }
}
