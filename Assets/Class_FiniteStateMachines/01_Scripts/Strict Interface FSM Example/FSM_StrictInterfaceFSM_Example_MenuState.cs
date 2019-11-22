using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is our Menu State class, which inherits from our "FSM_IState" interface
// this also means this class, must implement the interface's 3 methods: "Enter", "Execute", "Exit"
public class FSM_StrictInterfaceFSM_Example_MenuState : FSM_IState
{
    // a private variable to store the Menu screen, which will be received from the "StateMachine" script
    private GameObject menu;
    // a reference for our StateMachine script, so we can change the state from here, this reference will also be sent from the "StateMachine" script
    private FSM_StrictInterfaceFSM_Example_StateMachine stateMachine;

    // Constructor
    // here we get our references from the "StateMachine" script, so we can setup our state behaviour
    public FSM_StrictInterfaceFSM_Example_MenuState(FSM_StrictInterfaceFSM_Example_StateMachine _stateMachine, GameObject _menu)
    {
        menu = _menu;
        stateMachine = _stateMachine;
    }

    // Enter method (inherited from the "FSM_IState" interface)
    public void Enter()
    {
        // this state class only needs to deal with its own behaviour, so it only needs to enable the Menu screen when it enters the "Menu" state
        menu.SetActive(true);
    }

    // Execute method (inherited from the "FSM_IState" interface)
    public void Execute()
    {
        // if we're currently in the Menu,we can only Start the game from here
        if (Input.GetKeyDown(KeyCode.J))
        {
            // we call the method to change our state, since we have a reference for our "StateMachine" script
            // and since our State classes references are "public static" we can access them anywhere
            stateMachine.SetGameState(FSM_StrictInterfaceFSM_Example_StateMachine.gameState);
        }
    }

    // Exit method (inherited from the "FSM_IState" interface)
    public void Exit()
    {
        // disables the Menu screen when it exits this state
        menu.SetActive(false);
    }
}
