using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// every time we use UI variables in Unity we need use this
using UnityEngine.UI;

public class UserInterface_Dropdown_Example : MonoBehaviour
{
    // we hold the dropdown, so we can access its values/properties
    public Dropdown dropdown;

    // this method can be assigned to a Toggle "OnValueChanged" event
    // by doing so, every time the value of the Dropdown with this method assigned changes (is different than before), this method is called
    // - since we get it automaticaly from the Toggle component (select the method from the "Dynamic bool" section, once the script is assigned) and we don't need to assign it on the event's inspector    public void OnValueChangedToggle(bool _isOn)
    public void OnDropdownValueChanged()
    {
        // get the currently selected option from that dropdown
        Dropdown.OptionData curValueOpt = dropdown.options[dropdown.value];

        // get the text of that option
        string curValueText = curValueOpt.text;

        // get the image of that option
        Sprite curValueSprite = curValueOpt.image;

        Debug.Log("Text: " + curValueText + " // Image: " + curValueSprite.name);
    }
}
