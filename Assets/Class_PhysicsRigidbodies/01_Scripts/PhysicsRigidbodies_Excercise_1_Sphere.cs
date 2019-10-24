using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRigidbodies_Excercise_1_Sphere : MonoBehaviour
{
    // movement variables
    public float force;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // we need to store our Rigidbody as a reference. In this case instead of making the variable "public" and assign it on the inspector
        // we get the component at the start of the sphere's lifetime
        rb = GetComponent<Rigidbody>();

        // Since we want to make our sphere behave as if it is being "thrown" we should only apply the force once: 
        // - in real life we'd only throw the ball - apply force to it - once to make it move and leave our hand
        // As such, the ForceMode should be "ForceMode.Impulse"
        // Everything else works as the previous type of movement: We give it a direction and apply a force to it (similar to the "speed" when we move the object directly via transform)
        Vector3 translation = transform.forward;
        rb.AddForce(translation * force, ForceMode.Impulse);
    }

}
