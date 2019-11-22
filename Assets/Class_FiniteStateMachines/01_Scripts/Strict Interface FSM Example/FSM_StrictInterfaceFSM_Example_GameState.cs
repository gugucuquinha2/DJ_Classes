using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is our Game State class, which inherits from our "FSM_IState" interface
// this also means this class, must implement the interface's 3 methods: "Enter", "Execute", "Exit"
public class FSM_StrictInterfaceFSM_Example_GameState : FSM_IState
{
    // a private variable to store the game behaviour, which will be received from the "StateMachine" script
    private FSM_Movement movementScript;
    // a reference for our StateMachine script, so we can change the state from here, this reference will also be sent from the "StateMachine" script
    private FSM_StrictInterfaceFSM_Example_StateMachine stateMachine;

    // Constructor
    // here we get our references from the "StateMachine" script, so we can setup our state behaviour
    public FSM_StrictInterfaceFSM_Example_GameState(FSM_StrictInterfaceFSM_Example_StateMachine _stateMachine, FSM_Movement _movementScript)
    {
        movementScript = _movementScript;
        stateMachine = _stateMachine;
    }

    // Enter method (inherited from the "FSM_IState" interface)
    public void Enter()
    {
        // this state class only needs to deal with its own behaviour, so it only needs to enable the game behaviour when it enters the "Game" state
        movementScript.enabled = true;
    }

    // Execute method (inherited from the "FSM_IState" interface)
    public void Execute()
    {
        // if we're currently playing the actual Game, we can either lose thegame and go to GameOver...
        if (Input.GetKeyDown(KeyCode.K))
        {
            // we call the method to change our state, since we have a reference for our "StateMachine" script
            // and since our State classes references are "public static" we can access them anywhere
            stateMachine.SetGameState(FSM_StrictInterfaceFSM_Example_StateMachine.gameOverState);
        }
        // ...or go back to the Menu
        else if (Input.GetKeyDown(KeyCode.L))
        {
            // we call the method to change our state, since we have a reference for our "StateMachine" script
            // and since our State classes references are "public static" we can access them anywhere
            stateMachine.SetGameState(FSM_StrictInterfaceFSM_Example_StateMachine.menuState);
        }
    }

    // Exit method (inherited from the "FSM_IState" interface)
    public void Exit()
    {
        // disables the game behaviour when it exits this state
        movementScript.enabled = false;
    }
}
