using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// every time we use UI variables in Unity we need use this
using UnityEngine.UI;

public class UserInterface_SliderVolume_Example : MonoBehaviour
{
    public AudioSource aSource;

    // in this case, since we're using a reference of our slider outside of the event method, we have a reference for it for the whole script
    // so we can get access to the slider's properties and values
    public Slider slider;

    private void Start()
    {
        // at the start of the game, we make our AudioSource's volume to be of the same value as our slider
        // since the AudioSource's volume is linear (goes from 0 to 1 - same as our slider) we can change it directly
        aSource.volume = slider.value;
    }

    // this method can be assigned to a Slider "OnValueChanged" event
    // by doing so, every time any slider's value, with this method assigned changes, this method is called
    public void OnValueChangedSlider()
    {
        // every time our slider's value changes, we apply that value to the AudioSource's volume
        aSource.volume = slider.value;
    }
}
