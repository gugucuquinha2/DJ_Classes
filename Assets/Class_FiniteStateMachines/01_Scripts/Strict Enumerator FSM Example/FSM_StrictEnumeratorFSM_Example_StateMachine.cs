using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// STATE MACHINE USING ENUMERATORS //
// - This example is a "Strict" FSM, since the state updates depend on the current state we're at in the game

public class FSM_StrictEnumeratorFSM_Example_StateMachine : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        // once we start our game, we set our initial game state, in this case (as in most games) we start in the menu
        curGameState = GameState.Menu;
        // we also call the method with the "Menu" state behaviour for the first time, so we can set it up to start the game
        OnMenu();
    }

    // For this specific example, we're changing the states with Update keys, but in a game, they could be during the actual game:
    // - The "Menu" state could be set at the beginning of the game and when we return to the menu screen
    // - The "Game" state could be set once we press a "Start Game" button on our menu
    // - The "Game Over" state could be set once our character's health reaches 0
    // - Etc.
    private void Update()
    {
        SetGameState();
    }

    // This method is the one that manages and changes our states, but with more strict rules:
    // - We can only change to states that our current state allows us
    // - We have a specific and controlled (strict) state flow
    public void SetGameState()
    {
        switch (curGameState)
        {
            // if we're currently in the Menu...
            case GameState.Menu:

                // ...we can only Start the game from here,
                // so our game, will only detect input to start the game, optimizing our code from unnecessary input detection from other states
                if (Input.GetKeyDown(KeyCode.J))
                {
                    curGameState = GameState.Game;
                    OnGame();
                }

                break;
            // if we're currently playing the actual Game...
            case GameState.Game:

                // ... we can either lose thegame and go to GameOver...
                if (Input.GetKeyDown(KeyCode.K))
                {
                    curGameState = GameState.GameOver;
                    OnGameOver();
                }
                // ...or go back to the Menu
                else if (Input.GetKeyDown(KeyCode.L))
                {
                    curGameState = GameState.Menu;
                    OnMenu();
                }

                break;
            // if we just lost the Game...
            case GameState.GameOver:

                // ... we can only return to the Menu to restart the Game
                if (Input.GetKeyDown(KeyCode.L))
                {
                    curGameState = GameState.Menu;
                    OnMenu();
                }

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
