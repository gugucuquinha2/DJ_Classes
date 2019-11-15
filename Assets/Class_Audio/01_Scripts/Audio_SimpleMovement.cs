using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_SimpleMovement : MonoBehaviour
{
    public float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(hor, 0, ver);

        transform.position += direction * speed;
    }
}
