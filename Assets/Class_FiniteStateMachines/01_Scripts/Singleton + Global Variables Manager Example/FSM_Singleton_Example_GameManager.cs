using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSM_Singleton_Example_GameManager : MonoBehaviour
{
    private void Awake()
    {
        // if we check for the reference of our "GameManager" before assigning it a value, it will return null or empty
        Debug.Log("Before assigning the value: " + FSM_Singleton_Example_GlobalVarsManager.Instance.GameManager);

        // Our singleton allows us to get its value from wherever we are, even without a reference on this script

        // Each referenced script on the "GlobalVarsManager" needs to assign its own value to the reference, 
        // usally at Awake(), because we want to make sure to have a reference before the game starts, so we can use it when needed
        // if we don't do this, the reference "FSM_Singleton_Example_GlobalVarsManager.Instance.GameManager" or any other reference existant in the "GlobalVarsManager" would be useless
        FSM_Singleton_Example_GlobalVarsManager.Instance.GameManager = this;
    }

    void Start()
    {
        // we can see that once we start the game, our reference will have a value, because it's already assigned
        Debug.Log("After assigning the value: " + FSM_Singleton_Example_GlobalVarsManager.Instance.GameManager);
    }
}
