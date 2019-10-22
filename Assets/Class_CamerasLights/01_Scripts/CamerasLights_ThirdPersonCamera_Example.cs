using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasLights_ThirdPersonCamera_Example : MonoBehaviour
{
    public float speed;
    public GameObject spherePrefab;
    public Transform weaponTransform;
    public Transform rotator;

    float horRot = 0;
    float verRot = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // CUBE MOVEMENT
        MoveCube();

        // STORE ROTATION INPUT
        RotationInput();

        // CUBE ROTATION
        RotateCube();

        // SHOOT SPHERE
        ShootSphere();
    }

    // Late Update should always be used when moving a camera
    void LateUpdate()
    {
        // CAMERA ROTATION
        RotateRotator();
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

        // if we're using the "left"/"right" keys...
        if (hor != 0)
        {
            //... move the cube to its right direction (defined by the cube's horizontal rotation)
            // which multiplied by our input value "hor" will give us input-based negative (moving left) or positive (moving right) values
            transform.position += transform.right * hor * speed;
        }
        // if we're using the "up"/"down" keys...
        if (ver != 0)
        {
            //... move the cube to its forward direction (defined by the cube's horizontal rotation)
            // which multiplied by our input value "hor" will give us input-based negative (moving down) or positive (moving up) values
            transform.position += transform.forward * ver * speed;
        }
    }

    // Since we're separating cube's and camera rotation and we're using global variables for the rotations ("horRot" and "verRot")
    // We can use a function only to store rotation input
    private void RotationInput()
    {
        // store the input values from our mouse movement, continuously adding those values to global variables(outside of any method or callback)
        // so the position of our cube/ camera won't reset back to 0 after we stop moving the mouse and it stays where we last left it:
        // - because the range from "Input.GetAxis()" goes through negtive and positive values, and it defaults to 0 when there's no input
        horRot += Input.GetAxis("Mouse X");
        // the axis of the camera transform where we'll be using with "Mouse Y" is the "X", which by default will:
        // - by rotating it up > give us negative values
        // - by rotating it down > give us positive values
        // so instead of ADDING values we SUBTRACT them using "-=" so our input is not inverted (moving the mouse up will make us look up and vice-versa)
        verRot -= Input.GetAxis("Mouse Y");

        // we use "Mathf.Clamp" to limit the vertical rotation, so it doens't look unnatural
        // the method returns a "float" so we need to apply its value to the actual variable "verRot" for it to take effect
        verRot = Mathf.Clamp(verRot, 0, 70);
    }

    private void RotateCube()
    {
        // in this case we separate the rotations because we only want the cube to use the mouse rotation horizontally (sideways)
        // the up/down rotation should only affect the rotator (see "RotateRotator" method below)
        Vector3 cubeRotation = new Vector3(0, horRot, 0);

        // apply the rotation to the cube
        transform.rotation = Quaternion.Euler(cubeRotation);
    }

    private void RotateRotator()
    {
        // in this case we separate the rotations because we only want the cube to use the mouse rotation horizontally (sideways)
        // the up and down should only affect the camera
        Vector3 rotatorRotation = new Vector3(verRot, 0, 0);

        // in this case, we're rotating our rotator, which works as a pivot for our camera, 
        // this means that when we're rotating the rotator, the camera will be moving relative to that rotator (the camera is a child of the rotator)
        // and since the rotator has the same position as the cube, the camera will rotate relative to the cube and behave like a Third Person Camera
        // our camera is a CHILD of our cube we need to use "localRotation" instead of "rotation"
        // so the rotation is relative to the parent's rotation, in this case, the rotator - so we don't get weird behaviour
        rotator.localRotation = Quaternion.Euler(rotatorRotation);
    }

    private void ShootSphere()
    {
        // calculates the offset of the sphere position so it can be instance at the tip of the weapon
        // the "transform.position" of the weapon is at it's center, so we need to calculate half the longest side of the weapon (Y axis) 
        // to add it as an offset to the instance position
        Vector3 offset = weaponTransform.up * weaponTransform.localScale.y * 0.5f;

        // every time we press the button "Shoot" we instantiate a new bullet
        if (Input.GetButtonDown("Shoot"))
        {
            // the bullet will be coming out of the weapon and not the cube this time
            Instantiate(spherePrefab, weaponTransform.position + offset, weaponTransform.rotation);
        }
    }
}
