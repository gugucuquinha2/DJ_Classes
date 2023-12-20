using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityGameplay_Exercise_3 : MonoBehaviour
{
    // array of colliders
    private Collider[] colliders;

    // Start is called before the first frame update
    void Start()
    {
        // gets all colliders in the object holding this script and all its children
        colliders = GetComponentsInChildren<Collider>();
        
        // get the 3rd children Collider
        // since the parent also has a Collider:
        // - Parent index = 0
        // - Child nº1 index = 1
        // - Child nº2 index = 2
        // - Child nº3 index = 3 (THE ONE WE WANT)
        Debug.Log(colliders[3]);
    }
}
