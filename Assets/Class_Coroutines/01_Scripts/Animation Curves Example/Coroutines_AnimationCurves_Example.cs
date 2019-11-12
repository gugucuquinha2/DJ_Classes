using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines_AnimationCurves_Example : MonoBehaviour
{
    private bool move;

    // public reference of an Animation Curve so we can edit it in the inspector
    public AnimationCurve curve;

    // coroutine animation
    public Transform coroutineCube;
    private Coroutine coroutine;

    private Vector3 initialPos;
    private Vector3 endPos;

    // Start is called before the first frame update
    void Start()
    {
        move = false;

        // our "coroutineCube" default position is its initial position
        initialPos = coroutineCube.position;

        // our end position (where the animation ends) is the same as the default position, but inverted on the X axis
        // since our camera is at position 0, everything to the left of the camera will have a negative X value and anything to the right of the camera will have it positive
        // we want to move our cube from left to right, so we mirror the X position so the cube moves to the other side of the camera
        endPos = new Vector3(-coroutineCube.position.x, coroutineCube.position.y, coroutineCube.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            // we set the animation bool value
            // if it's true becomes false and vice-versa
            move = !move;

            Vector3 targetPos = Vector3.zero;
            // if the animation boolean is true 
            if (move)
            {
                // that means our animation should follow the animator animation and as such, the targetPos of our animation is the "endPos"
                targetPos = endPos;
            }
            // if the animation boolean is true 
            else
            {
                // that means our animation should follow the animator animation and as such, the targetPos of our animation is the "initialPos", 
                // since the cube is getting back to its initial position
                targetPos = initialPos;
            }

            // it's very important to hold a reference of the current active coroutine (if there's one) so we now specifically what coroutine to stop, when we need to do so
            // in this case, we need to stop the current coroutine, every time we want to change the target position of our animation, 
            // so it considers the current of the cube, as the new initial position of the animation
            if (coroutine != null)
                StopCoroutine(coroutine);

            // after making our cube stop, we can now create a new coroutine and assign it to our reference
            coroutine = StartCoroutine(CubeMovement(targetPos));
        }
    }

    private IEnumerator CubeMovement(Vector3 _targetPos)
    {
        // we save the current position of our cube, so we can use it as our initial position of the animation
        Vector3 initialAnimationPos = coroutineCube.position;

        // the duration of our animation
        float duration = 3;

        // the percentage of completion (progress) of our animation (0 = 0%, 1 = 100%)
        float t = 0;

        // while our animation isn't complete (hasn't reached 100%/1)
        while (t < 1)
        {
            // we keep adding the current frame's progress to our total progress (t):
            // - "Time.deltaTime" gives us the duration in seconds of 1 frame
            // - If we divide the duration of 1 frame, by the total animation duration, we get the amount of progress the animation makes in 1 frame (in percentage)
            // - if every frame we animate, we add that frame's progress to the total animation progress, we'll gradually increase t over our "duration"
            // - the animation will stop once "t" reaches 1
            float progressPerFrame = Time.deltaTime / duration;
            t += progressPerFrame;

            // tipically an animation curve is a graph that goes from 0 to 1 on the X axis (this axis is generally considered as time, or in our case progress)
            // while the Y axis is used to determine what values we get at a specific time or progress
            // this fits perfectally to use animation curves with our animation progress "t"
            // With the method "Evaluate()" we can specify how our "Lerp" interpollation behaves and make it more smooth (just like we have in the standard animation curves)
            float smoothness = curve.Evaluate(t);

            // Vector3.Lerp(Vector3 a, Vector3 b, float t) linearlly interpolates a Vector3 from "a" to "b" over "t" (t represents the percentage/progress of the interpolation):
            // - if "t" is 0, that means the interpolation is of 0%, so we get the same value of "a"
            // - if "t" is 1, that means the interpolation is of 100%, so we get the same value of "b" 
            // - if "t" is 0.35f, that means the interpolation is of 35%, so we get a value between "a" and "b" (which in this case will be closer to "a")
            // - etc

            // since our "t" value is gradually increased, our interpolation will be animated from "a" (our "initialAnimationPos") to "b" (our "_targetPos")
            // by applying this interpolation to our coroutineCube's position, we'll make it move and animate
            coroutineCube.position = Vector3.Lerp(initialAnimationPos, _targetPos, smoothness);

            // since we're dealing with animation and we usually want them to be smooth (as it would be with standard keyframe animations) we want changes to happen every frame
            // for that we use "yield return null" that only halts the coroutine execution for one frame at a time
            yield return null;
        }
    }
}
