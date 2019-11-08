using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation_Example : MonoBehaviour
{
    private Animator animator;

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
                animator.SetBool("Run", true);
            }
            // if there's no input, the character can't run
            else
            {
                animator.SetBool("Run", false);
            }
        }
        // if we release it, then the character stops running
        else if (Input.GetButtonUp("Fire3"))
        {
            animator.SetBool("Run", false);
        }
    }
}
