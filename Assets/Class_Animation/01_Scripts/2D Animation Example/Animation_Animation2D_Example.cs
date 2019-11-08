using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Animation2D_Example : MonoBehaviour
{
    private Animator animator;
    public float speed;

    // default scale of our sprite
    public Vector3 spriteScale = new Vector3(10, 10, 1);

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float hor = Input.GetAxis("Horizontal");

        // since it is a 2D sprite, we only care about horizontal movement (left/right)
        Vector3 translation = new Vector3(hor, 0, 0);

        // if we're using keys (otherwise we'll have undesired changes when not moving with the keys - because the value of "hor" will get back to 0)
        if (Input.GetButton("Horizontal"))
        {
            // and the input is smaller than 0 (meanign we're moving left)...
            if (hor < 0)
            {
                // ...we flip our sprite left
                transform.localScale = new Vector3(-spriteScale.x, spriteScale.y, spriteScale.z);
            }
            // if the input is bigger than 0 (meaning we're moving right)...
            else
            {
                // ...we flip our sprite right
                transform.localScale = new Vector3(spriteScale.x, spriteScale.y, spriteScale.z);
            }
        }

        transform.position += translation * speed;

        // set the float of our animator parameter
        // the method "Mathf.Abs()" is used to return the absolute value of a variable, meaning that it will always return the positive value of a number:
        // - our "Run" parameter expects that values lower than "0.01" mean our character is idle
        // - but in fact our movement values range from -1 to 1, while 0 means we're not moving
        // - so to counter the fact that -1 is considered lower than "0.01" (our animator considers that to be idle), 
        // we need to make sure that it assumes a positive value for movement that returns negative values - SO WE USE "Mathf.Abs()"
        animator.SetFloat("Run", Mathf.Abs(hor));
    }
}
