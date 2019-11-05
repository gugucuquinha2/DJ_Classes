using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_ChargeJump : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce = 8;

    private bool canJump;

    // this variable is a reference of our script that deals with the animation
    private Animation_ChargeJump_SphereAnimationHandler animHandler;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // since our script works as a component as well (inherits from the "MonoBehaviour" class)
        // we can get access to it using "GetComponent" or by assigning it in the inspector (if the variable was public)
        animHandler = GetComponent<Animation_ChargeJump_SphereAnimationHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        // if we press space, we charge the jump
        if (Input.GetButtonDown("Jump"))
        {
            // We check if our object is touching the ground. Since our object's scale is 1, that means that if its position (which is  measured at its center) is 0.5f, it will be touching the ground
            // use a value a little bit bigger than 0.5f so it still works even when the object is still touching the ground, but on a different angle
            // it's simple way of only allowing us to jump, when the object's at the ground
            if (transform.position.y < 0.6f)
            {
                // we move our animator to the state of the charge animation
                animHandler.JumpAnimation(true);
                // and we're now ready to jump (we can jump)
                canJump = true;
            }
        }
        // when we release space, we actually jump
        else if (Input.GetButtonUp("Jump"))
        {
            // if we can jump
            if (canJump)
            {
                // we can't jump again
                canJump = false;

                // apply the force up
                rb.velocity = Vector3.up * jumpForce;
                // // we move our animator to the state of the actual jump animation
                animHandler.JumpAnimation(false);
            }
        }
    }
}
