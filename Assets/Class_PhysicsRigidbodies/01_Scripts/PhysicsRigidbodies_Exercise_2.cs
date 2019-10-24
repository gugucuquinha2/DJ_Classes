using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRigidbodies_Exercise_2 : MonoBehaviour
{
    // movement variables
    public float force;
    private Vector3 translation;

    // prefab variables
    public GameObject spherePrefab;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // MOVEMENT
        MoveCube();

        // SHOOT SPHERE
        ShootSphere();
    }

    private void MoveCube()
    {
        // get the Axis value of the virtual buttons
        // returns a range of values from [-1, 1], depending of the pressed key
        // EXAMPLE for the "Horizontal" virtual button:
        // - if "left arrow" (the negative button) is pressed, value will gradually move to -1
        // - if "right arrow" (the positive button) is pressed, value will gradually move to 1
        // - if no button is pressed, value will return to 0
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        // setup a translation (direction) for the movement
        // since the values range from [-1, 1] they are a good way of setting our direction
        translation = new Vector3(hor, 0, ver);

        // In this case, since we're constantly updating the force of the object its best to use "ForceMode.Force", which applies a continous force on our object
        rb.AddForce(translation * force, ForceMode.Force);
    }

    private void ShootSphere()
    {
        // calculates the offset of the sphere position so it can be instance at the tip of the weapon
        // the "transform.position" of the object is at it's center, so we need to calculate half the longest side of the object (since its a cube, it doesn't mather) 
        // to add it as an offset to the instance position
        Vector3 offset = transform.forward * transform.localScale.y * 0.5f;

        // every time we press the button "Shoot" we instantiate a new bullet
        // In this case, since we're applying movement to our object purely through Physics, we don't have a lot of control over the orientation of our object
        // this means that the firing may not work correctly (but we'll keep just to understand what happens)
        if (Input.GetButtonDown("Shoot"))
        {
            Instantiate(spherePrefab, transform.position + offset, transform.rotation);
        }
    }
}
