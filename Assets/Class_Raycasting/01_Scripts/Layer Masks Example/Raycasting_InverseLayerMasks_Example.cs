using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycasting_InverseLayerMasks_Example : MonoBehaviour
{
    public float distance = 5f;

    // Update is called once per frame
    void Update()
    {
        // Allows to create a visual representation of our raycast (ONLY VISIBLE ON THE SCENE WINDOW)
        // Since it doens't have any argument for the "distance" value, we multiply our distance by the direction
        Debug.DrawRay(transform.position, transform.forward * distance, Color.red);

        // The ray we're going to cast, it contains a starting position ("transform.position") and a direction ("transform.forward")
        // In this case, this means we're casting our ray from the object to 5 units forward (relative to the object's transform)
        Ray ray = new Ray(transform.position, transform.forward);

        // here our "LayerMask" is preceded by a "~" oeprator which means "inverse":
        // - in this situation, only the layers "Post 1" and "Post 3" WON'T be able to be detected by our Raycast
        LayerMask mask = ~(LayerMask.GetMask("Post 1", "Post 3"));
        //same as (the "|" means the same as "&&" on if statements):
        //LayerMask mask = ~(1 << LayerMask.NameToLayer("Post 1") |
        //                 1 << LayerMask.NameToLayer("Post 3"))

        // we then cast the ray, if it hits something, will debug the gameObject that was hit
        // since we're making our Raycasts inside the "Update()", we're doing calculations for RaycastHits EVERY FRAME:
        // - this is not great for performance, so we should be contained in the way we use raycasts
        // notice that now, our raycast is referencing the "mask" variable, so it knows which layers to ignore/consider
        if (Physics.Raycast(ray, out RaycastHit hit, distance, mask))
        {
            Debug.Log(hit.transform.gameObject);
        }
    }
}
