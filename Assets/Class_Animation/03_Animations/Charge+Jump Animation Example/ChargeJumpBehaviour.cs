using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeJumpBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // we can use the animator reference here, to call other components attached to our gameObject
        // and do whatever we want/need
        Debug.Log("Example of what to get with a state machine behaviour: " + animator.gameObject.GetComponent<Animation_ChargeJump>());

        // EXAMPLE:
        // - if we're toggling a flashlight and this is the state where you animate your character's arm to pickup the flashlight
        // - you can use this callback to: set the light ON, every time you enter this state
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // we can use the animator reference here, to call other components attached to our gameObject
        // Here we move our object a little bit forward, every time we exit the state where this script is in (the "ChargeJump" state)
        animator.transform.position += Vector3.forward;

        // EXAMPLE:
        // - if we're toggling a flashlight and the next state (the state where the character hides the flashlight)
        // - you can use this callback to: set the light OFF every time you exit this state
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
