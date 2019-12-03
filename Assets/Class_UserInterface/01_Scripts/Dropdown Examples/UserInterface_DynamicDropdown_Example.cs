using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// every time we use UI variables in Unity we need use this
using UnityEngine.UI;

public class UserInterface_DynamicDropdown_Example : MonoBehaviour
{
    // we hold the dropdown, so we can access its values/properties
    public Dropdown dropdown;

    private void Start()
    {
        // for this example, we're going to create 10 new options for our dropdown

        // first we create a new list of "Dropdown.OptionData" (the type of dropdown options) to hold our new Options
        // in real use, like with a list of screen resolutions, we may not need to create the list ourselves,
        // we're only doing so to show you the process of creating options
        List<Dropdown.OptionData> newOptions = new List<Dropdown.OptionData>();

        // a for loop will allow us to create the 10 options
        for (int i = 0; i < 10; i++)
        {
            // we create a new option
            Dropdown.OptionData opt = new Dropdown.OptionData();

            // and give it values (in this case only a string)
            // so we can see information about the options on the dropdown
            opt.text = "New Option_" + i;

            // and then add it to our list of new options
            newOptions.Add(opt);
        }

        // before applying our new options to the dropdown, we eleminate any current ones
        dropdown.ClearOptions();

        // and then add the options list to our dropdown
        dropdown.AddOptions(newOptions);
    }

    // this method can be assigned to a Toggle "OnValueChanged" event
    // by doing so, every time the value of the Dropdown with this method assigned changes (is different than before), this method is called
    // - since we get it automaticaly from the Toggle component (select the method from the "Dynamic bool" section, once the script is assigned) and we don't need to assign it on the event's inspector    public void OnValueChangedToggle(bool _isOn)
    public void OnDropdownValueChanged()
    {
        // get the currently selected option from that dropdown
        Dropdown.OptionData curValueOpt = dropdown.options[dropdown.value];

        // get the text of that option
        string curValueText = curValueOpt.text;

        Debug.Log("Dropdown value text: " + curValueText);
    }
}
