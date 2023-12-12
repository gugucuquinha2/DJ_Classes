﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInput_Exercise_2 : MonoBehaviour
{
    // movement variables
    public float speed;
    private Vector3 translation;

    private float hor;
    private float ver;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // MOVEMENT
        MoveCube();

        // ROTATION
        RotateCube(translation);
    }

    private void MoveCube()
    {
        // get the Axis value of the virtual buttons
        // returns a range of values from [-1, 1], depending of the pressed key
        // EXAMPLE for the "Horizontal" virtual button:
        // - if "left arrow" (the negative button) is pressed, value will gradually move to -1
        // - if "right arrow" (the positive button) is pressed, value will gradually move to 1
        // - if no button is pressed, value will return to 0
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        // setup a translation (direction) for the movement
        // since the values range from [-1, 1] they are a good way of setting our direction
        translation = new Vector3(hor, 0, ver);

        // apply the movement to this cube's transform
        transform.position += translation * (speed * Time.deltaTime);
    }

    private void RotateCube(Vector3 _translation)
    {
        // only rotate the cube if we're using the keys (so the cube doesn't rotate back to 0)
        if (hor != 0 || ver != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(translation);

            // apply the rotation
            // Quaternion.Slerp interpolates the rotation to our target rotation (cube's movement direction) by a percentage (speed * Time.deltaTime) every frame, smoothly rotating our cube
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
        }
    }
}
