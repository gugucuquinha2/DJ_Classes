using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// THIS EXERCISE IS A GOOD EXAMPLE OF HOW WE CAN USE RAYCASTS TO INTERACT WITH OBJECTS IN THE GAME WORLD ///
/// This can easily be used to make a "point-n-click" game, where we use raycasts to move our character, or interact with the environment, just as we do in this exercise!
/// </summary>

public class Raycasting_Exercise_2 : MonoBehaviour
{
    // for this example, we need a reference to the "Camera" component itself
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        // if our camera is tagged as "MainCamera", then we can acess it via script, like this
        // which in this case, is
        cam = Camera.main;
    }

    private void Update()
    {
        // the virtual button of the Input Manager which uses the "Left Mouse Button" is "Fire1"
        // by raycasting only when we press the button we're significantly reducing the times we're making our raycast, improving the performance of its use
        if (Input.GetButtonDown("Fire1"))
        {
            // we can access the mouse position on the screen using "Input.mousePosition"
            Vector3 mousePos = Input.mousePosition;

            // this ray, results from the conversion of our mouse position, from "Screen Space" (pixels) to a Ray in world sapce
            // the ray goes from the camera to a world point (which is mappped from our mouse position)
            Ray ray = cam.ScreenPointToRay(mousePos);

            // we can now use this ray in our raycast
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // to change the scale of a transform by 10%, we simply need to multiply it by 1.1 (representing an increase of 0.1 - 10%, over it's regular scale of 1)
                hit.transform.localScale *= 1.1f;
            }
        }
    }
}
