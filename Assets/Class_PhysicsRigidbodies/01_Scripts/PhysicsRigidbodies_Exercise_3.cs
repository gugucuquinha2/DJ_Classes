using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsRigidbodies_Exercise_3 : MonoBehaviour
{
    // movement variables
    public float force;
    public float jumpForce;
    private Vector3 translation;

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
        Jump();
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

    private void Jump()
    {
        // first, we check if our object is touching the ground. Since our object's scale is 1, that means that if its position (which is  measured at its center) is 0.5f, it will be touching the ground
        // use a value a little bit bigger than 0.5f so it still works even when the object is still touching the ground, but on a different angle
        // it's simple way of only allowing us to jump, when the object's at the ground
        if (transform.position.y <= 0.8f)
        {
            // if it is, then we can jump (we're using the virtual button "Shoot" still, because its key is the spacebar)
            if (Input.GetButtonDown("Shoot"))
            {
                // once we jump, we add a force vertically
                // we directly change the velocity, because we want an immediate change to the velocity, so the jump is quicker
                // we use "Vector3.up" because we want our jump to always be up:
                // - if we used "transform.up", we would be depending on the rotation of our object and 
                // - since we're applying a force that can change it, we need to make sure we always go up
                rb.velocity = Vector3.up * jumpForce;
            }
        }
    }
}
