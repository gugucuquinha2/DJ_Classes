using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders_Exercise_3_Collision : MonoBehaviour
{
    private int goals;

    private void Start()
    {
        goals = 0;
    }

    // Detects the frame whenever an object enters the trigger of the obejct to which this script is attached to
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            // only detects collision, if the gameObject has the corresponding tag

            // we can for example, store in a variable how many goals we've scored;
            goals++;

            Debug.Log("GOAL!!! - Score: " + goals);

            
        }
    }
}
