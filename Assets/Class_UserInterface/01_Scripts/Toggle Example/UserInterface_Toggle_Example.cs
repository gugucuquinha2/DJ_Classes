using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// every time we use UI variables in Unity we need use this
using UnityEngine.UI;

public class UserInterface_Toggle_Example : MonoBehaviour
{
    // this method can be assigned to a Toggle "OnValueChanged" event
    // by doing so, every time the value of Toggle with this method assigned changes (is different than before), this method is called
    // in this case, this method has an argument of type "bool", which is dynamic:
    // - since we get it automaticaly from the Toggle component (select the method from the "Dynamic bool" section, once the script is assigned) and we don't need to assign it on the event's inspector 
    public void OnValueChangedToggle(bool _isOn)
    {
        Debug.Log("The toggle is: " + _isOn);
    }
}
