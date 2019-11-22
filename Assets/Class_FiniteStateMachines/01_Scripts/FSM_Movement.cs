using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Movement : MonoBehaviour
{
    public float speed = 0.2f;

    private Vector3 scale;

    private void Start()
    {
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal");
        
        Vector3 translation = new Vector3(hor, 0);

        if (hor != 0)
        {
            transform.position += translation * speed;

            if (hor < 0)
            {
                transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
            }
            else if (hor > 0)
            {
                transform.localScale = scale;
            }
        }
    }
}
