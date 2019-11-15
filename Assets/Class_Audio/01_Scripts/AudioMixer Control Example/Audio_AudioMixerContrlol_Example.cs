using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio_AudioMixerContrlol_Example : MonoBehaviour
{
    public AudioMixer audioMixer;

    // our snapshots references (work as presets of AudioMixer settings)
    public AudioMixerSnapshot sfxOnlySnap;
    public AudioMixerSnapshot musicOnlySnap;

    // Update is called once per frame
    void Update()
    {
        // AUDIO MIXER CONTROL EXAMPLE //

        if (Input.GetKeyDown(KeyCode.H))
        {
            // allow us to change the value of the exposed parameter
            // the parameter must be exposed on the AudioMixer before it can be used
            // setting values directly like this overrides any snapshot
            audioMixer.SetFloat("MusicVolume", -30);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            // allows a transition from the current snapshot to the target snapshot (in this case "sfxOnlySnap")
            sfxOnlySnap.TransitionTo(0.5f);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            // this blends between snapshots
            // we need to define the array of snapshots to blend
            // and their weights (the weights should be in the same order as the snapshots array)

            AudioMixerSnapshot[] snaps = { sfxOnlySnap, musicOnlySnap };
            float[] snapsWeights = { 0.2f, 0.8f };

            audioMixer.TransitionToSnapshots(snaps, snapsWeights, 3f);
        }
    }
}
