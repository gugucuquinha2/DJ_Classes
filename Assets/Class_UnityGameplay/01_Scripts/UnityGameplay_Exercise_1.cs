using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityGameplay_Exercise_1 : MonoBehaviour
{
    public float speed;
    private Vector3 translation;

    // Start is called before the first frame update
    void Start()
    {
        // store a reference to the wanted translation
        translation = new Vector3(1, 0, 0);
        // or
        // translation = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        // apply the movement to this cube's transform
        transform.Translate(translation * speed);
        // or
        //transform.position += translation * speed;
    }
}
