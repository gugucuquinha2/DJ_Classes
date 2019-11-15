using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Footsteps_Example : MonoBehaviour
{
    // audio
    public AudioSource audioSource;
    public AudioClip clip;

    // coroutine
    private Coroutine co;

    // movement
    public float speed = 0.1f;
    private bool isWalking;

    private void Start()
    {
        // at the beginning of the game, the character is not walking
        isWalking = false;

        // setup the audioSource
        audioSource.clip = clip;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        // SIMPLE MOVEMENT //

        float ver = Input.GetAxis("Vertical");
        float hor = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(hor, 0, ver);

        transform.Translate(direction * speed, Space.World);

        // AUDIO //

        // if we're actually pressing any keys to move our character
        if (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Horizontal"))
        {
            // the cube's walking
            isWalking = true;

            // check if the AudioSource with the footsteps sound is not playing already
            // without this, we would always restart the footsteps every time we pressed the movement keys
            if (!audioSource.isPlaying)
            {
                // play the footsteps soun
                audioSource.Play();
            }
        }

        // if our character is not moving and "isWalking" is true (we do this so this condition is only entered once, as soon as we stop pressing the movement keys)
        if (ver == 0 && hor == 0 && isWalking)
        {
            // we immediatly say our character is not walking anymore (to avoid the condition being enteres again)
            isWalking = false;

            // if our coroutine to stop the footsteps audio is already running, we stop it, so we can start a new one
            if (co != null)
                StopCoroutine(co);

            // we start a new coroutine to stop the footsteps and assign it to our coroutine reference for future use
            co = StartCoroutine(WaitForFootsepToEnd());
        }
    }

    private IEnumerator WaitForFootsepToEnd()
    {
        // since our footsteps sound is on loop, we get the time where the footsteps sound is at:
        // - so we can wait until it finishes to stop the sound from playing again
        float time = audioSource.time;

        // so we wait until the time is equal to the footsteps clip length (then we know it finished playing)
        while (time < clip.length)
        {
            // but while the time is still smaller than the clip lentgh, we keep waiting
            time += Time.deltaTime;

            yield return null;
        }

        // once the time reaches the clip length (meaning this loop ended)
        // we can stop the sound
        audioSource.Stop();
    }
}
