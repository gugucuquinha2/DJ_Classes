using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// STATE MACHINE USING ENUMERATORS //
// - This example is a "Free" FSM, since we can change the states freely, when we want

public class FSM_EnumeratorFSM_Example_StateMachine : MonoBehaviour
{
    // this public variable is the one that stores the current state of our game,
    // is of type "GameState" so it will store values from that enumerator
    public GameState curGameState;

    // in order to be able to successfully manage the different states, our State Machine needs to be aware of what objects/scripts to handle
    // so we need references for them, in this example we have one GameObject/Script per state
    // NOTE: If we wanted to organize our code better, we could have another script which would be our "DataHolder" to hold all these references
    // and then we could retrieve them when needed
    public GameObject menu;
    public GameObject gameOver;
    public FSM_Movement movementScript;

    private void Awake()
    {
        // at awake (before our game actually starts) we set our game state to "None", 
        //because we only want to setup our state to actually have behaviour at the begnning of the game (from Start)
        curGameState = GameState.None;
    }

    private void Start()
    {
        // so once we start our game, we set our initial game state, in this case (as in most games) we start in the menu
        SetGameState(GameState.Menu);
    }

    // For this specific example, we're changing the states with Update keys, but in a game, they could be during the actual game:
    // - The "Menu" state could be set at the beginning of the game and when we return to the menu screen
    // - The "Game" state could be set once we press a "Start Game" button on our menu
    // - The "Game Over" state could be set once our character's health reaches 0
    // - Etc.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SetGameState(GameState.Game);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            SetGameState(GameState.GameOver);
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            SetGameState(GameState.Menu);
        }
    }

    // This method is the one that manages and changes our states
    public void SetGameState(GameState _state)
    {
        // if our current game state is the same of our target state...
        if (curGameState == _state)
        {
            // ...we exit from the method and don't do anything
            return;
        }

        // we update our state...
        curGameState = _state;

        // ...and now check what this new state will do to our game and apply the changes
        switch (curGameState)
        {
            case GameState.Menu:
                OnMenu();
                break;

            case GameState.Game:
                OnGame();
                break;

            case GameState.GameOver:
                OnGameOver();
                break;
        }
    }

    // Method that holds changes when we enter the "Game Over" state
    private void OnGameOver()
    {
        // we disable everything that is not supposed to show or do something when we lose the game
        menu.SetActive(false);
        movementScript.enabled = false;

        // and enable the game over screen
        gameOver.SetActive(true);
    }

    // Method that holds changes when we enter the "Menu" state
    private void OnMenu()
    {
        // we disable everything that is not on the menu
        gameOver.SetActive(false);
        movementScript.enabled = false;

        // and enable our menu
        menu.SetActive(true);
    }

    // Method that holds changes when we enter the "Game" state
    private void OnGame()
    {
        // we disable everything that doesn't exist in-game
        menu.SetActive(false);
        gameOver.SetActive(false);

        // and enable our input/game behaviour
        movementScript.enabled = true;
    }
}
