using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_AudioMixerChannelFadeOut_Example : MonoBehaviour
{
    public AudioMixer audioMixer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeOutAudio());
    }

    private IEnumerator FadeOutAudio()
    {
        // first we need to get the parameter we want to fade-out of the AudioMixer channel
        // since we're fading volume in this case, we'll be getting Logarithmic values (decibels - dB)
        float curMixerVol;
        audioMixer.GetFloat("MusicVolume", out curMixerVol);

        // since we're animating using "Mathf.Lerp" which interpolates values in a linear way, we need to convert our logarithmic values (-80 to 0) to linear values (0 to 1)
        // for that we use the following expression:
        curMixerVol = Mathf.Pow(10, curMixerVol / 20);

        // we set the duration of our animation
        float duration = 7;
        // our progress variable (goes from 0% to 100% - 0 to 1)
        float t = 0;
        // and then we do our while loop to change values over time
        while (t < 1)
        {
            t += Time.deltaTime / duration;

            // this Lerp allow us to change our values based on our progress (t)
            // notice that we're not fading our volume to 0, because if we do so:
            // - when we convert our volume back to logarithmic values to apply to our AudioMixer channel, we'll get the volume back to its default, 
            // since the "Mathf.Log10() of 0 will return a logarithmic value of 0 dB"
            // to prevent that, we simply set our Lerp to target some value close to 0 (0.0001f in this case), which when converted to dB represents an inaudible volume
            float lerpedVol = Mathf.Lerp(curMixerVol, 0.0001f, t);

            // we then simply need to reconvert our linear animated/lerped values back to logarithmic (dB)
            // we do so, using another standard expression:
            float mixerVolume = Mathf.Log10(lerpedVol) * 20;

            // finally we apply the volume back to the AudioMixer channel
            audioMixer.SetFloat("MusicVolume", mixerVolume);

            // since these changes in the volume happen every frame our coroutine is running, we'll have our volume smoothly fade-out
            yield return null;
        }
    }
}
