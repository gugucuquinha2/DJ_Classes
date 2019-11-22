using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// STATE MACHINE USING INTERFACES //
// - This example is a "Strict" FSM, since the state updates depend on the current state we're at in the game

public class FSM_StrictInterfaceFSM_Example_StateMachine : MonoBehaviour
{
    // this public variable is the one that stores the current state of our game,
    // is of the same type of our interface "FSM_IState" so we can store whatever state its currently set (because all of them  inherit from "FSM_IState")
    public FSM_IState curGameState;

    // with interfaces, each state is defined by a Class which inherits from the "FSM_IState" interface, inheriting its methods
    // which allow us to deal with all state change behaviour
    // one way of dealing with the way we can access these states (since they're classes that need to be instanced)
    // is storing them as "public static" references (so they can be accessed wherever we need them) and so that we can recycle the code:
    // - since we only have 1 instance of each state throughout our game (created on Awake())
    // the more states we have the more references we need to have, so another solution is to create a new instance of our state class each time we change the state
    // (our code gets less crowded, but its worse for performance and memory allocation)
    public static FSM_StrictInterfaceFSM_Example_GameState gameState;
    public static FSM_StrictInterfaceFSM_Example_MenuState menuState;
    public static FSM_StrictInterfaceFSM_Example_GameOverState gameOverState;

    // in order to be able to successfully manage the different states, our State Machine needs to be aware of what objects/scripts to handle
    // so we need references for them, in this example we have one GameObject/Script per state
    // NOTE: If we wanted to organize our code better, we could have another script which would be our "DataHolder" to hold all these references
    // and then we could retrieve them when needed
    public GameObject menu;
    public GameObject gameOver;
    public FSM_Movement movementScript;

    private void Awake()
    {
        // at awake (before our game actually starts) create instances of all our states and give them the references of GameObjects/Scripts they need
        // so they can manage themselves (a big advantage over using Enumerators is that FSM's with interfaces only need to "worry" about their own behaviour and elements - it's more modular and organized)
        gameState = new FSM_StrictInterfaceFSM_Example_GameState(this, movementScript);
        menuState = new FSM_StrictInterfaceFSM_Example_MenuState(this, menu);
        gameOverState = new FSM_StrictInterfaceFSM_Example_GameOverState(this, gameOver);
    }

    void Start()
    {
        // we call a method to setup our scene  (disable all GameObjects/Scripts in this case) so we can set up our initial state
        InitializeObjs();
        // then we set our initial game state, in this case (as in most games) we start in the menu
        SetGameState(menuState);
    }

    // The difference from the "Free" FSM is that now, instead of changing our states freely, in that case - in the Update,
    // we're letting our states deal with the state changes, this means, that each state will decide to what state they can go to:
    // - We can only change to states that our current state allows us
    // - We have a specific and controlled (strict) state flow
    void Update()
    {
        if(curGameState != null)
        {
            // with interfaces, we only need to call our Execute(), to check where can we go from our current state, since, as we've seen before, 
            // each State class will be self-sufficient and will deal with the possible state changes 
            //(is checked every frame, because it deals with input detection for this example) 
            curGameState.Execute();
        }
    }

    // This method is the one that manages and changes our states
    // It's much simpler than the FSM using Enumerators, because all the behaviour is set in each State class
    public void SetGameState(FSM_IState _state)
    {
        // if we're already at some state
        if (curGameState != null)
        {
            // we exit from it
            // this means the current state will "deal with itself" and cleanup their GameObjects/Scripts
            // so the next state only needs to deal with himself as well
            curGameState.Exit();
        }

        // we update our state
        curGameState = _state;

        // and enter the new state
        curGameState.Enter();
    }

    private void InitializeObjs()
    {
        menu.SetActive(false);
        gameOver.SetActive(false);
        movementScript.enabled = false;
    }
}
