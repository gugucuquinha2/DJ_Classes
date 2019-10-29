using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders_FPCannon_Example_Collision : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 350f;

    // once the cannon ball collides with anything
    private void OnCollisionEnter(Collision collision)
    {
        // calls the explosion method to create an explosion in the position of the cannon ball ("transform.position")
        Explode(transform.position);

        // after the explosion destroy the cannon ball (this gameObject)
        Destroy(gameObject);
    }

    private void Explode(Vector3 _position)
    {
        // This new method "Physics.OverlapSphere" creates a detection area (sphere) which returns all colliders within its radius (in this case the "explosionRadius")
        Collider[] colliders = Physics.OverlapSphere(_position, explosionRadius);

        //this array of colliders will allow us to look for any Rigidbody in their GameObjects
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rb = colliders[i].GetComponent<Rigidbody>();

            // only apply the explosion, if the object has a rigidbody (!= null), 
            //otherwise an error will occur (because we would be trying to add a force to a non-existant rigidbody)
            if (rb != null)
            {
                // the explosion requires a force, a position (same as our overlap sphere) and
                // a radius (again, same as before in our overlap sphere - so it's consistent with our detected objects)
                rb.AddExplosionForce(explosionForce, _position, explosionRadius);
            }
        }
    }
}
