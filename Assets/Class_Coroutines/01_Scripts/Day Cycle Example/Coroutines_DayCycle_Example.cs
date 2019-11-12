using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines_DayCycle_Example : MonoBehaviour
{
    public Transform lightTransform;
    private Coroutine coroutine;

    // the duration of the one cycle (day)
    public float duration = 5;

    // Start is called before the first frame update
    void Start()
    {
        // start the day cycle for the first time, hold the coroutine as a reference for later use
        coroutine = StartCoroutine(DayCycle());
    }

    private IEnumerator DayCycle()
    {
        // how much do we want to rotate during a cycle (in this case, 360º, the equivalent to 24h)
        float cycleRotation = 360;

        // the passed time variable
        float time = 0;
        // here our while behaves a little differently, since we don't need our progress, we don't use "t"
        // we simply check if the time passed is smaller than the limit duration
        while (time < duration)
        {
            time += Time.deltaTime;

            // in order to rotate our light, we use the "Rotate" method instead of the usual "Lerp" or "Slerp"
            // we do this, because interpollations with rotations are not consistent, since angles can be ambiguous (ex: -90º = 270º) so the way our light would rotate could be inconsistent
            // a solution is to simply constinuously increment the rotation, this way we make sure the rotation happens always in the same direction

            // we want to rotate 360º degrees (a full day of our cycle), to do this, we need to find how many angles our light should rotate per frame of animation
            // to do so we first need to know how many frames the total duration of our animation will have:
            // - we can get it by dividing our total duration by the duration of one single frame (duration / Time.deltaTime)
            // - then we need to divide our desired cycle rotation by the total number of frames for our animation (cycleRotation / animationFrames)
            // that way we get to know how much should we rotate on our "Rotate" method
            float animationFrames = duration / Time.deltaTime;
            float anglesPerFrame = cycleRotation / animationFrames;

            // once we get our values, we can then use the Rotate method to rotate our light
            // in this case it's important to specify the axis we want to rotate around (in this case is the Y axis = Vector.right)
            // we should specify Space value as "Space.Self" so the rotation is made relatively to the lights own rotation
            lightTransform.Rotate(Vector3.right, anglesPerFrame, Space.Self);

            yield return null;
        }

        // once a full cycle ends, we stop the current coroutine
        StopCoroutine(coroutine);
        // and start a new one, so a new cycle (day) happens, creating a dynamic day cycle
        coroutine = StartCoroutine(DayCycle());
    }
}
