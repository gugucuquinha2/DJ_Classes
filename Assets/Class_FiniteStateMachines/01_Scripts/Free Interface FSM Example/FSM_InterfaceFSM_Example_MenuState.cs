using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is our Menu State class, which inherits from our "FSM_IState" interface
// this also means this class, must implement the interface's 3 methods: "Enter", "Execute", "Exit"
public class FSM_InterfaceFSM_Example_MenuState : FSM_IState
{
    // a private variable to store the Menu screen, which will be received from the "StateMachine" script
    private GameObject menu;

    // Constructor
    // here we get our references from the "StateMachine" script, so we can setup our state behaviour
    public FSM_InterfaceFSM_Example_MenuState(GameObject _menu)
    {
        menu = _menu;
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
        // no behaviour needed here in this example
    }

    // Exit method (inherited from the "FSM_IState" interface)
    public void Exit()
    {
        // disables the Menu screen when it exits this state
        menu.SetActive(false);
    }
}
