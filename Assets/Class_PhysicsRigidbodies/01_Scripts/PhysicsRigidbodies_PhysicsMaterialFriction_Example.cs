using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRigidbodies_PhysicsMaterialFriction_Example : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(transform.forward * 5, ForceMode.Impulse);
    }
}
