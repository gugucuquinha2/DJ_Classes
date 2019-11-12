using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coroutines_Exercise_1 : MonoBehaviour
{
    private Vector2 targetPos;
    public AnimationCurve curve;

    // Start is called before the first frame update
    void Start()
    {
        targetPos = new Vector2(transform.position.x + 12, transform.position.y + 3);

        StartCoroutine(SpriteAnimation());
    }

    private IEnumerator SpriteAnimation()
    {
        Vector2 initialPos = transform.position;

        float duration = 3;
        float t = 0;
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

            // since our "t" value is gradually increased, our interpolation will be animated from "a" (our "initialAnimationPos") to "b" (our "_targetPos")
            // by applying this interpolation to our sprite's position, we'll make it move and animate
            transform.position = Vector2.Lerp(initialPos, targetPos, smoothness);

            // since we're dealing with animation and we usually want them to be smooth (as it would be with standard keyframe animations) we want changes to happen every frame
            // for that we use "yield return null" that only halts the coroutine execution for one frame at a time
            yield return null;
        }
    }
}
