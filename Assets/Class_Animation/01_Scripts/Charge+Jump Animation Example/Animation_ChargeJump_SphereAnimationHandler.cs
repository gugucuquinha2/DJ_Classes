using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script created to handle animation related methods for our object 
// and to work as an example of communication between scripts

public class Animation_ChargeJump_SphereAnimationHandler : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // since our animator is just a component, we can access it using "GetComponent"
        animator = GetComponent<Animator>();
    }

    // this method will be called, once we want our jump animation to be called
    public void JumpAnimation(bool _jumpBool)
    {
        // the name "Jump", must be the same as our parameter in the animator controller
        // we use a bool, because in this case, we have a binary approach to the jump:
        // - charging jump > the jump button is being pressed > "true"
        // - relasing jump > the jump button is release > "false"
        animator.SetBool("Jump", _jumpBool);
    }

    // This method, if associated to an Animation Event, will be triggered every time its animation runs and passes to the frame where the event is set
    // NOTICE: if the specified animations exists more than once in the animator, this event will be triggered for every animation where the event is set
    public void JumpAnimationEventExample()
    {
        Debug.Log("Event triggered");
    }
    // We can also pass one argument, which can be assigned in the inspector (when the event is selected in the animation)
    public void JumpAnimationEventExampleWithGameobject(int _number)
    {
        Debug.Log("Event triggered with a parameter: " + _number);
    }
}
