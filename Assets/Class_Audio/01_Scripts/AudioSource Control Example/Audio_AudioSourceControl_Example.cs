using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_AudioSourceControl_Example : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip clip1;
    public AudioClip clip2;
    public AudioClip clip3;

    // Start is called before the first frame update
    void Start()
    {
        // get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // assign a new clip to the AudioSource (whatever clip was there before is disabled, even if it was playing)
        audioSource.clip = clip1;

        // set the AudioSource to loop its sound
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        // AUDIO SOURCE CONTROL EXAMPLE //

        if (Input.GetKeyDown(KeyCode.H))
        {
            // play the current clip
            audioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            // assign a new clip to the AudioSource (whatever clip was there before is disabled, even if it was playing)
            audioSource.clip = clip2;
            // play the current clip
            audioSource.Play();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            // even if there's already a playing clip on the AudioSource this sound (clip3) will always play
            // it plays every time we call the method (if you continuously call this, they will overlap each other)
            audioSource.PlayOneShot(clip3);
        }

        else if (Input.GetKeyDown(KeyCode.Y))
        {
            // stops the currently playing clip
            // this means once we use audioSource.Start() the clip will start from the default time:
            // - usually 0, if we didn't change the "time" property of the AudioSource
            audioSource.Stop();
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            // pauses the currently playing clip
            audioSource.Pause();
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            // the "time" property gives us the current time that our AudioSource is at and we can change it
            // in this example, we use the current AudioSource clip "length" property which gives us the total length of our clip,
            // to set the playback time at half of the clip's lentgh.

            // NOTE: once the "audioSource.time" is changed, its new value becomes the time where every clip assigned to this AudioSource starts playing from
            audioSource.time = audioSource.clip.length * 0.5f;
        }
    }
}
