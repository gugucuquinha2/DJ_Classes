using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInput_Exercise_3_Sphere : MonoBehaviour
{
    // movement variables
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // in this situation, since our sphere instance is already setup with the cube's position/rotation, it also has it's direction
        // so we use the sphere's forward vector (transform.forward) as our translation, 
        // so the sphere can be shot forward along the direction of the cube, at the moment it instanced the sphere
        Vector3 translation = transform.forward;
        transform.position += translation * speed;
    }
}
