using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRigidbodies_Explosion_Example : MonoBehaviour
{
    private Vector3 explosionPosition;
    public float explosionRadius;
    public float explosionForce;

    private void Start()
    {
        // sincer our cubes are at the positon (0, 0, 0). Our explosion position will be in the middle of them, for greater effect
        explosionPosition = Vector3.zero;
    }

    void FixedUpdate()
    {
        // if we press "space"
        if (Input.GetButtonDown("Shoot"))
        {
            // we cause an explosion
            Explode();
        }
    }

    private void Explode()
    {
        // This new method "Physics.OverlapSphere" creates a detection area (sphere) which returns all colliders within its radius (in this case the "explosionRadius")
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, explosionRadius);

        //this array of colliders will allow us to look for any Rigidbody in their GameObjects
        for (int i = 0; i < colliders.Length; i++)
        {
            Rigidbody rb = colliders[i].GetComponent<Rigidbody>();

            // only apply the explosion, if the object has a rigidbody (!= null), 
            //otherwise an error will occur (because we would be trying to add a force to a non-existant rigidbody)
            if(rb != null)
            {
                // the explosion requires a force, a position (same as our overlap sphere) and
                // a radius (again, same as before in our overlap sphere - so it's consistent with our detected objects)
                rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
            }
        }
    }
}
