using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting_FoV_Example_BulletMovement : MonoBehaviour
{
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * speed;
    }
}
