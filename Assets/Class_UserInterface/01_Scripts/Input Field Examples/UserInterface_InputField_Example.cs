using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// every time we use UI variables in Unity we need use this
using UnityEngine.UI;

public class UserInterface_InputField_Example : MonoBehaviour
{
    // this method can be assigned to an InputField "OnValueChanged" event
    // by doing so, every time the value of the InputField with this method assigned changes (be it adding or removing a new letter, or adding a space), this method is called
    // in this case, this method has an argument of type "InputField", we need to assign it in the inspector of the "OnValueChanged" event, so we can use it
    public void OnInputFieldValueChanged(InputField _inputField)
    {
        // everytime we change somethig in our input field we want to display the last key of the text

        // to do so, we need to get all characters in the text separately
        char[] charArray = _inputField.text.ToCharArray();

        // and if there's any characters in the input field
        if(charArray.Length > 0)
        {
            // we debug the last of them
            Debug.Log(charArray[charArray.Length-1]);
        }
    }

    // this method can be assigned to a InputField "OnEndEdit" event
    // by doing so, every time we finish editing (either by submiting it, or selecting another UI element) the value of the InputField with this method assigned, this method is called
    // in this case, this method has an argument of type "InputField", we need to assign it in the inspector of the "OnValueChanged" event, so we can use it
    public void OnInputFieldEndEdit(InputField _inputField)
    {
        // usually this event type is used, when we want to get the final value of the input field:
        // - like submit a form
        // - send an email
        // - login into an account
        // - etc

        Debug.Log(_inputField.text);
    }
}
