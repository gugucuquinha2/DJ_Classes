using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLights_SpherePrefab_Movement : MonoBehaviour
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
        // in this situation, since our sphere instance is already setup with the weapon's position/rotation, it also has it's direction
        // so we use the sphere's up vector (transform.up) as our translation, 
        // since that's the orientation of our weapon in the scene (check the "green arrow" in the scene)
        Vector3 translation = transform.up;
        transform.position += translation * speed;
    }
}
