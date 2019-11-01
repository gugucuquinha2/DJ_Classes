using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting_Exercise_1 : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject child;

    private bool canRaycast;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canRaycast = true;

        // we can get the parachute (child of the falling object) right at the beginning
        // the bool "true" specifies that our "GetComponentsInChildren" is also supposed to search on inactive objects (such as our parachute), otherwise we get an error
        // in our array, we want the transform of the child, since "GetComponentsInChildren", searches in both the parent and the children:
        // - since we only have 2 objects, it will return 2 transforms, being the second (index 1) the transform of the child (parachute)
        Transform childTransform = GetComponentsInChildren<Transform>(true)[1];
        // get the gameObject associated to that transform 
        // notice that since a GameObject isn't a Component, we can't search directly for GameObjects using "GetComponentsInChildren" - we can only search for an actual component
        child = childTransform.gameObject;
    }

    void FixedUpdate()
    {
        // to improve the performance and so that our Raycast is only made when needed (before touching the ground)
        // we check for this boolean
        if (canRaycast)
        {
            // we debug the ray so we can see what's happening
            Debug.DrawRay(transform.position, Vector3.down * 6, Color.green);

            Ray ray = new Ray(transform.position, Vector3.down);

            // since we're using Tag check and not LayerMasks, we don't need any LayerMasks on our Raycast
            if (Physics.Raycast(ray, out RaycastHit hit, 6))
            {
                // this is another way of limiting Raycast detections
                // just like we'd do with the "OnCollisionEnter", etc, callbacks
                // NOTICE: Using LayerMasks is still preferrable, because with tags, the Raycast is still made every frame (in this case), we're simply checking if it collides with our "Ground" before applying the behaviour
                // LayerMasks are better because they actually prevent Raycast collision on the specified layers
                if (hit.transform.gameObject.CompareTag("Ground"))
                {
                    // once we detect the ground, we can say we can't raycast anymore, so the next frame, our FixedUpdate stops at the the first boolean check
                    // preventing unnacessary raycasts to be made and saving performance (we can check if it worked, by observing our "DrawRay" dissapear once the Raycast detects the ground)
                    canRaycast = false;

                    // we change the drag value of the Rigidbody of our falling object (will result in a sudden slow down of the falling object)
                    rb.drag = 6;
                    // and we active the gameObject of the child, so it looks like the parachute is making the object slow down
                    child.SetActive(true);
                }
            }
        }
    }
}
