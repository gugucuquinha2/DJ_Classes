using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityInput_Exercise_1 : MonoBehaviour
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
        Vector3 translation = new Vector3(hor, 0, ver);

        // apply the movement to this cube's transform
        transform.position += translation * (speed * Time.deltaTime);
    }
}
