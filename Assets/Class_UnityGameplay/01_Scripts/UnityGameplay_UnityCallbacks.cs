using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityGameplay_UnityCallbacks : MonoBehaviour
{
    //------------------------------------------------------------------

    // HERE IT IS SPECIFIED THE ORDER OF THE DIFFERENT UNITY CALLBACKS
    // MORE INFO AT: https://docs.unity3d.com/Manual/ExecutionOrder.html

    //------------------------------------------------------------------

    // This function is always called before any Start functions and also just after a prefab
    // is instantiated. (If a GameObject is inactive during start up Awake is not called until it is made active.)
    private void Awake()
    {
        Debug.Log("Awake");
    }

    // (only called if the Object is active): This function is called just after the object is enabled.
    // This happens when a MonoBehaviour instance is created, such as when a level is loaded or a GameObject with the script component is instantiated.
    private void OnEnable()
    {
        Debug.Log("On Enable");
    }

    // Start is called before the first frame update only if the script instance is enabled.
    void Start()
    {
        Debug.Log("Start");
    }

    // All physics calculations and updates occur immediately after FixedUpdate.
    // It can be called multiple times per frame, if the frame rate is low and it may not be called between frames at all if the frame rate is high.
    // FixedUpdate is called on a reliable timer, independent of the frame rate.
    private void FixedUpdate()
    {
        Debug.Log("Fixed Update");
    }

    // Update is called once per frame. It is the main workhorse function for frame updates.
    void Update()
    {
        Debug.Log("Update");
    }

    // LateUpdate is called once per frame, after Update has finished. 
    // Any calculations that are performed in Update will have completed when LateUpdate begins. 
    // A common use for LateUpdate would be a following third-person camera. 
    // If you make your character move and turn inside Update, you can perform all camera movement and rotation calculations in LateUpdate. 
    // This will ensure that the character has moved completely before the camera tracks its position.
    private void LateUpdate()
    {
        Debug.Log("Late Update");
    }

    // This function is called after all frame updates for the last frame of the object’s existence
    // (the object might be destroyed in response to Object.Destroy or at the closure of a scene).
    private void OnDestroy()
    {
        Debug.Log("On Destroy");
    }

    // This function is called when the behaviour becomes destroyed, disabled or inactive.
    private void OnDisable()
    {
        Debug.Log("On Disable");
    }
}
