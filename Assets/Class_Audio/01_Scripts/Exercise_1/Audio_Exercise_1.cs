using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Exercise_1 : MonoBehaviour
{
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        // we store the initial volume of our audioSource for the animation
        float initialVol = audioSource.volume;

        // we set our duration
        float duration = 7;
        // our progress variable (goes from 0% to 100% - 0 to 1)
        float t = 0;
        // and then we do our while loop to change values over time
        while (t < 1)
        {
            t += Time.deltaTime / duration;

            // this Lerp allow us to change our values based on our progress (t)
            // and apply those values directly to the audioSource
            audioSource.volume = Mathf.Lerp(initialVol, 0, t);

            // since these changes in the volume happen every frame our coroutine is running, we'll have our volume smoothly fade-out
            yield return null;
        }
    }

}
