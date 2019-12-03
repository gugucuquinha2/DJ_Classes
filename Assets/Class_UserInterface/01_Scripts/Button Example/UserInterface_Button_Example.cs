using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// every time we use UI variables in Unity we need use this
using UnityEngine.UI;

public class UserInterface_Button_Example : MonoBehaviour
{

    // this method can be assigned to a Button "OnClick" event
    // by doing so, every time any button with this method assigned is clicked, this method is called
    // in this case, this method has an argument of type "Button", we need to assign it in the inspector of the "OnClick" event, so we can use it
    public void OnClickButton(Button _button)
    {
        Debug.Log(_button.name);
    }
}
