using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLayers_2D_Example : MonoBehaviour
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
        // CROUCH MID-AIR //

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("TopBodyAction");
        }
    }
}
