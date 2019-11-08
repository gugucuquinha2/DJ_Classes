using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation_Exercise_1 : MonoBehaviour
{
    private Animator animator;
    public float speed;
    private float runMultiplier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        // we get our direction vector using the input, but we multiply it immediatly by our speed
        // we do this, so we can multiply this direction by our "run multiplier", which will increase the speed of the movement to match our running animation
        
        Vector3 direction = new Vector3(hor, 0, ver) * speed;

        // WALK //

        // since our blend tree uses 2 parameters called "Vertical" and "Horizontal" which are floats
        // we can setup the animations using the exact sames values that we use in our input
        animator.SetFloat("Vertical", ver);
        animator.SetFloat("Horizontal", hor);

        // RUN //

        // while we keep the "left shift" key pressed, our character is running
        if (Input.GetButton("Fire3"))
        {
            // but he only runs, if we have input (the character isn't still/idle)
            if (ver != 0 || hor != 0)
            {
                // NOTICE: With this movement code, we shouldn't multiply the "speed" variable instead of the "direction", because
                // being the speed a constant value, it will be multiplied every frame by our run multiplier, increasing dramatically and creating faulty behaviour (in this case)
                // since our direction is updated every frame (and we already multiply the speed in its definition), we can multiply it every frame
                direction *= runMultiplier;
                animator.SetBool("Run", true);
            }
            // if there's no input, the character can't run
            else
            {
                // if our character is not running, then we don't need to multiply our direction by any values
                animator.SetBool("Run", false);
            }
        }
        // if we release it, then the character stops running
        else if (Input.GetButtonUp("Fire3"))
        {
            // if our character is not running, then we don't need to multiply our direction by any values
            animator.SetBool("Run", false);
        }

        // ADD MOVEMENT //
        transform.position += direction;
    }
}
