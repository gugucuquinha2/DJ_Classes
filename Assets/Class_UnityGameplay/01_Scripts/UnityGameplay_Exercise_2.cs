using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityGameplay_Exercise_2 : MonoBehaviour
{
    // movement variables
    public float speed;
    private Vector3 translation;

    // rotation variables
    public float rotationValue;
    private Vector3 axis;

    // Start is called before the first frame update
    void Start()
    {
        // store a reference to the wanted translation
        translation = new Vector3(0, 1, 0);
        // or
        // translation = Vector3.right;

        // store a reference to the wanted rotation axis
        axis = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // apply the movement to this cube's transform
        transform.Translate(translation * (speed * Time.deltaTime));
        // or
        //transform.position += translation * speed;

        // apply the rotation to this cube's transform
        transform.Rotate(axis, rotationValue * Time.deltaTime);
    }
}
