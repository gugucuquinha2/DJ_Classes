using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script created to handle animation related methods for our object 
// and to work as an example of communication between scripts

public class Animation_SphereAnimationHandler : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // since our animator is just a component, we can access it using "GetComponent"
        animator = GetComponent<Animator>();
    }

    // this method will be called, once we want our jump animation to be called
    public void JumpAnimation()
    {
        // we use trigger, because our Animator for this gameObject is also a Trigger type parameter
        // the name "Jump", must be the same as our parameter in the animator controller
        animator.SetTrigger("Jump");
    }
}
