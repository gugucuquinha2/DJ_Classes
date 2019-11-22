using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this is our Game Over State class, which inherits from our "FSM_IState" interface
// this also means this class, must implement the interface's 3 methods: "Enter", "Execute", "Exit"
public class FSM_InterfaceFSM_Example_GameOverState : FSM_IState
{
    // a private variable to store the Game Over screen, which will be received from the "StateMachine" script
    private GameObject gameOver;

    // Constructor
    // here we get our references from the "StateMachine" script, so we can setup our state behaviour
    public FSM_InterfaceFSM_Example_GameOverState(GameObject _gameOver)
    {
        gameOver = _gameOver;
    }

    // Enter method (inherited from the "FSM_IState" interface)
    public void Enter()
    {
        // this state class only needs to deal with its own behaviour, so it only needs to open the GameOver screen when it enters the "GameOver" state
        gameOver.SetActive(true);
    }

    // Execute method (inherited from the "FSM_IState" interface)
    public void Execute()
    {
        // no behaviour needed here in this example
    }

    // Exit method (inherited from the "FSM_IState" interface)
    public void Exit()
    {
        // disables the Game Over screen when it exits this state
        gameOver.SetActive(false);
    }
}
