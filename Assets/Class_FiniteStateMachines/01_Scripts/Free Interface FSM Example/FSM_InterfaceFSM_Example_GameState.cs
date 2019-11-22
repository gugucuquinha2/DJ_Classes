using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is our Game State class, which inherits from our "FSM_IState" interface
// this also means this class, must implement the interface's 3 methods: "Enter", "Execute", "Exit"
public class FSM_InterfaceFSM_Example_GameState : FSM_IState
{
    // a private variable to store the game behaviour, which will be received from the "StateMachine" script
    private FSM_Movement movementScript;

    // Constructor
    // here we get our references from the "StateMachine" script, so we can setup our state behaviour
    public FSM_InterfaceFSM_Example_GameState(FSM_Movement _movementScript)
    {
        movementScript = _movementScript;
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
        // no behaviour needed here in this example
    }

    // Exit method (inherited from the "FSM_IState" interface)
    public void Exit()
    {
        // disables the game behaviour when it exits this state
        movementScript.enabled = false;
    }
}
