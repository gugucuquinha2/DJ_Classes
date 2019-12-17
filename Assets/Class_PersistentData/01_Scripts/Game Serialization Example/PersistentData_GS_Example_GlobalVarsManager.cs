using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this reference allow us to determine which classes are going to be saved/loaded through the "[Serializable]" header:
// - like the "GameData" class, in this case
using System;

public class PersistentData_GS_Example_GlobalVarsManager
{
    #region Singleton
    private static PersistentData_GS_Example_GlobalVarsManager instance;
    public static PersistentData_GS_Example_GlobalVarsManager Instance
    {
        get
        {
            if (instance == null)
            {
                new PersistentData_GS_Example_GlobalVarsManager();
            }

            return instance;
        }
    }

    public PersistentData_GS_Example_GlobalVarsManager()
    {

        if (instance != null)
        {
            return;
        }

        instance = this;
    }
    #endregion


    // globally accessible reference for our GameManager
    private static PersistentData_GS_Example_GameManager gameManager;
    public PersistentData_GS_Example_GameManager GameManager
    {
        get
        {
            return gameManager;
        }
        set
        {
            gameManager = value;
        }
    }

    // globally accessible reference for our PlayerMovement
    private static PersistentData_GS_Example_Movement playerMovement;
    public PersistentData_GS_Example_Movement PlayerMovement
    {
        get
        {
            return playerMovement;
        }
        set
        {
            playerMovement = value;
        }
    }

    // globally accessible reference for our GameData class instance
    // since we only want to have one instance to save (meaning one save file), 
    // we can instance our GameData class at the same time we provide a global acess point to it
    // this way we make sure we only get 1 instance of this class, preventing errors associated with saving/loading the wrong instances of this class
    private static GameData gameData;
    public GameData GameData
    {
        get
        {
            // if our instance is null...
            if (gameData == null)
            {
                // ...we create a new one...
                gameData = new GameData();
            }

            // ...and return it
            return gameData;
        }
        set
        {
            gameData = value;
        }
    }
}

// everytime we want to save a class, we need to make sure it can be serialized by adding the header "[Serializable]"
// having a specific class to hold all information we want to save/load is the most convenient and organized way to store only the information we need saving
[Serializable]
public class GameData
{
    // but in this case, since saving a game can be complex and can scale overtime, we're saving instances of other classes
    // which themselves hold information about their respective task
    // this way each part of the game takes care of its own data (modular approach) making it easier to manage and debug and it's scalable (if the game grows bigger)

    // PlayerData - hold all information to be saved regarding the player (health, position, stats, etc)
    // since this an instance of a class, we don't have default values, a reference to the instance of PlayerData in use has to be assigned elsewhere 
    // (usually in the same place the data management regarding the player is made - in this case, in the script "PersistentData_GS_Example_Movement")
    public PlayerData playerData;

    // LevelData - hold all information to be saved regarding the level (current level, scores, etc)
    // since this an instance of a class, we don't have default values, a reference to the instance of LevelData in use has to be assigned elsewhere
    // (usually in the same place the data management regarding the level is made - in this case, in the script "PersistentData_GS_Example_GameManager")
    public LevelData levelData;
}
