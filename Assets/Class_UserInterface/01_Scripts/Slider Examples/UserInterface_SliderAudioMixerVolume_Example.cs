using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// every time we use UI variables in Unity we need use this
using UnityEngine.UI;

public class UserInterface_SliderAudioMixerVolume_Example : MonoBehaviour
{
    // instead of an AudioSource, we're changing the audio of an AudioMixer channel using our slider
    public AudioMixer aMixer;

    // in this case, since we're using a reference of our slider outside of the event method, we have a reference for it for the whole script
    // so we can get access to the slider's properties and values 
    public Slider slider;

    private void Start()
    {
        // at the start of the game, we make our AudioMixer's channel volume to be of the same value as our slider
        // since AudioMixer's volume is logarithmic (dB) and not linear we need to convert our slider values (linear) to logarithmic
        float logarithmicVol = ConvertToLogarithmic(slider.value);

        // then we can set the value of the AudioMixer's channel to the converted values
        aMixer.SetFloat("Volume", logarithmicVol);
    }

    // this method can be assigned to a Slider "OnValueChanged" event
    // by doing so, every time any slider's value, with this method assigned changes, this method is called
    public void OnValueChangedSlider()
    {
        // every time our slider's value changes, we apply that value to the AudioMixer's channel volume
        float logarithmicVol = ConvertToLogarithmic(slider.value);
        aMixer.SetFloat("Volume", logarithmicVol);
    }

    // this method returns a float, which is the result of the conversion of the linear values "_valueToChange" from our slider
    // to logarithmic values, based on the calculation "Mathf.Log10(_valueToChange) * 20"
    private float ConvertToLogarithmic(float _valueToChange)
    {
        return Mathf.Log10(_valueToChange) * 20;

        // NOTE: since the Mathf.Log10() of 0 will return a logarithmic value of 0 dB it's recommended that the Slider's minimum value is not 0:
        // - instead it should be a value close to it, like 0.00001, which when converted to dB represents an inaudible volume
    }
}
