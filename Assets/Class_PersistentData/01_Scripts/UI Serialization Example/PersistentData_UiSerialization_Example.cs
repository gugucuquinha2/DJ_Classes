using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this reference allow us to acess file management special methods and files:
// - like "File.WriteAllText()" or "File.ReadAllText()"
using System.IO;
// this reference allow us to determine which classes are going to be saved/loaded through the "[Serializable]" header:
// - like the "SettingsData" class, in this case
using System; 

public class PersistentData_UiSerialization_Example : MonoBehaviour
{
    // a reference for an instance of the class to be saved
    // this way we always know which instance will hold the settings information and be saved/loaded
    private SettingsData settingsData;

    // references for our UI elements, so we can get/set their values
    public Slider sliderUI;
    public Dropdown dropdownUI;
    public Toggle toggleUI;

    // this string will hold the path to where we'll save the file with the settings data
    // since it always remains the same, we can store it once at the start of the game
    private string savePath;

    // Start is called before the first frame update
    void Start()
    {
        // store the path to where we're saving the settings data
        // "Application.persistentDataPath" contains the path to a persistent directory/folder, which means
        // we should use this path everytime we want to save something in our game, since this path will be "persistent" throughout every game session
        // "/Settings.ui" is the name and extension (can be whatever we want) we're giving our file. 
        // The "/" indicates that the file is to be saved inside the "persistentDataPath" directory 
        savePath = Application.persistentDataPath + "/Settings.ui";

        // at the beginning of the game create and instance of our settings data class, 
        //this is the instance that'll be used to store all settings information to be saved/loaded
        settingsData = new SettingsData();

        // we call this method at the start of the game so we load the previous saved settings (if there's any) before the game starts
        // so the player's preferences are setup as soon as he starts to play
        LoadSettings();
    }

    private void ApplySettingsData()
    {
        // apply the values on our "settingsData" instance to the actual UI elements
        toggleUI.isOn = settingsData.toggle;
        sliderUI.value = settingsData.slider;
        dropdownUI.value = settingsData.dropdown;
    }

    // UI MANAGEMENT //

    // method that's used on the "OnValueChanged()" event of the Toggle UI element
    public void OnToggle(bool _isOn)
    {
        // everytime the toggle value changes, we update our instance of the SettingsData class
        // so we can save the latest prefences of the player
        settingsData.toggle = _isOn;
    }

    // method that's used on the "OnValueChanged()" event of the Slider UI element
    public void OnSlider()
    {
        // everytime the toggle value changes, we update our instance of the SettingsData class
        // so we can save the latest prefences of the player
        settingsData.slider = sliderUI.value;
    }

    // method that's used on the "OnValueChanged()" event of the Dropdown UI element
    public void OnDropdown()
    {
        // everytime the dropdown selected option value changes, we update our instance of the SettingsData class
        // so we can save the latest prefences of the player
        settingsData.dropdown = dropdownUI.value;
    }

    // SAVE/LOAD //

    public void SaveSettings()
    {
        // we serialize our class instance by converting it into a JSON string
        string json = JsonUtility.ToJson(settingsData);
        Debug.Log(json);

        // then, we write its content into a text file, which is specified in our "savePath" string
        // this will create a new file with the name and extension defined by the "savePath" and will contain all our settings data
        File.WriteAllText(savePath, json);
    }

    public void LoadSettings()
    {
        // we check if there's any saved file in the path we use to save the settings data:
        // - if there is, we load it
        // - if not, we don't need to load anything
        if (File.Exists(savePath))
        {
            // we read all the text present in the saved file and store it as a string (which is formatted as JSON)
            string json = File.ReadAllText(savePath);
            // then we use the method "JsonUtility.FromJson()" to deserialize our JSON string back into its original form:
            // - an instance of our SettingsData class, which will be assigned to our universal "settingsData" variable, so we can use it/update it once more 
            settingsData = JsonUtility.FromJson<SettingsData>(json);
            Debug.Log(json);
        }

        // once we've loaded the required information (or not - if there's no load file)
        // we always apply the changes to the UI elements, so they can take effect and the player can see them:
        // - if we didn't load anything, then the default values of the "settingsData" new instance will be considered
        // - if we loaded settings, the loaded values will be applied
        ApplySettingsData();
    }

    // we save the settings every time we exit the game (used here as an example)
    private void OnApplicationQuit()
    {
        SaveSettings();
    }
}


// everytime we want to save a class, we need to make sure it can be serialized by adding the header "[Serializable]"
// having a specific class to hold all information we want to save/load is the most convenient and organized way to store only the information we need saving
[Serializable]
public class SettingsData
{
    // we gave this porperties to be saved default values,
    // in case we don't have any data to load, this default vaues will be used instead
    public bool toggle = true;
    public float slider = 1;
    public int dropdown = 0;
}
