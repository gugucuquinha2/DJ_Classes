using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// this reference allow us to acess file management special methods and files:
// - like "File.WriteAllText()" or "File.ReadAllText()"
using System.IO;
// this reference allow us to determine which classes are going to be saved/loaded through the "[Serializable]" header:
// - like the "LevelData" class, in this case
using System;

public class PersistentData_GS_Example_GameManager : MonoBehaviour
{
    // a reference for the UI text displaying the current level
    public Text levelTxt;

    // a reference for an instance of the class to be saved
    // this way we always know which instance will hold the level information so we can pass it on to our GameData class to be saved
    public LevelData levelData;

    // this string will hold the path to where we'll save the file with the settings data
    // since it always remains the same, we can store it once at the start of the game
    private string savePath;

    private void Awake()
    {
        // we assign the GameManager global reference to this script, so it can be globally accessible
        PersistentData_GS_Example_GlobalVarsManager.Instance.GameManager = this;

        // store the path to where we're saving the settings data
        // "Application.persistentDataPath" contains the path to a persistent directory/folder, which means
        // we should use this path everytime we want to save something in our game, since this path will be "persistent" throughout every game session
        // "/GameData.game" is the name and extension (can be whatever we want) we're giving our file. 
        // The "/" indicates that the file is to be saved inside the "persistentDataPath" directory 
        savePath = Application.persistentDataPath + "/GameData.game";

        // before the game starts we create a new instance to be used of the LevelData class
        // but only if we don't already have one created (through loading)
        // this way we make sure we only get 1 instance of this class, preventing errors associated with saving/loading the wrong instance of this class
        if (levelData == null)
        {
            levelData = new LevelData();
        }
        // we associate our instance of the LevelData class in use to the one that's going to be saved and loaded at the GameData
        // now, every change we make to our local "levelData" variable, is going to automatically update the GameData's instance to be saved
        PersistentData_GS_Example_GlobalVarsManager.Instance.GameData.levelData = levelData;

        // this method updates the UI and the current stage of the game
        UpdateStage();
    }

    private void Start()
    {
        // at the start of the game we Load the current game
        Load();
    }

    // method called whenever the game is loaded
    // this method is only concerned about the LevelData, other systems should have a similar method to deal with their own data
    // again -  this way each part of the game takes care of its own data (modular approach) making it easier to manage and debug and it's scalable (if the game grows bigger)
    public void OnLoad(LevelData _levelData)
    {
        // update the instance of the LevelData class in use with the loaded one
        levelData = _levelData;
        // update the UI
        levelTxt.text = "Stage: " + levelData.level;
    }

    public void UpdateStage()
    {
        // increase the current level
        levelData.level++;
        // update the UI
        levelTxt.text = "Stage: " + levelData.level;
    }

    // SAVE/LOAD //

    public void Save()
    {
        // we serialize our GameData class instance by converting it into a JSON string
        string json = JsonUtility.ToJson(PersistentData_GS_Example_GlobalVarsManager.Instance.GameData);
        Debug.Log(json);

        // then, we write its content into a text file, which is specified in our "savePath" string
        // this will create a new file with the name and extension defined by the "savePath" and will contain all the game data we set to be saved
        File.WriteAllText(savePath, json);
    }

    public void Load()
    {
        // we check if there's any saved file in the path we use to save the game's data:
        // - if there is, we load it
        // - if not, we don't need to load anything
        if (File.Exists(savePath))
        {
            // we read all the text present in the saved file and store it as a string (which is formatted as JSON)
            string json = File.ReadAllText(savePath);
            // then we use the method "JsonUtility.FromJson()" to deserialize our JSON string back into its original form:
            // - an instance of our GameData class, which will be assigned to our global GameData instance variable, so we can use it/update it once more 
            PersistentData_GS_Example_GlobalVarsManager.Instance.GameData = JsonUtility.FromJson<GameData>(json);
            Debug.Log(json);

            // update all systems affected by the load
            // in this case every system, which has saved/loaded data has a method called "OnLoad" which is then called here, everytime the game is loaded
            PersistentData_GS_Example_GlobalVarsManager.Instance.PlayerMovement.OnLoad(PersistentData_GS_Example_GlobalVarsManager.Instance.GameData.playerData);
            OnLoad(PersistentData_GS_Example_GlobalVarsManager.Instance.GameData.levelData);
        }
    }
}

// everytime we want to save a class, we need to make sure it can be serialized by adding the header "[Serializable]"
// having a specific class to hold all information we want to save/load is the most convenient and organized way to store only the information we need saving
[Serializable]
public class LevelData
{
    // regarding the LevelData, we only want to save the current level the player's at
    public int level = 0;
}
