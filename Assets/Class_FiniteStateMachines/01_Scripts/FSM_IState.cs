
// Classes: 
// - Their purpose is to set a predefined behaviour and parameters that are common to all instances of that Class type
// - They can define and implement its methods and variables, their methods must have a body, otherwise it throws an error

// Interfaces:
// - Their purpose it to define a set of predefined methods, so that every object/class that inherits from them, will have to implement the methods the interface defines
// - Can only define methods, not implement them

// in this case, this means that our interface "FSM_IState" will define the methods we want our different states to have and implement (add behaviour):
// - "Enter" > The moment we enter the state (similar to a Start() callback)
// - "Execute" > The execution of our state (similar to a Update() callback)
// - "Exit" > The moment we exit the state (similar to a OnDisable() callback)
public interface FSM_IState
{
    void Enter();
    void Execute();
    void Exit();
}

// NOTE: These methods are more-or-less the common ones, but they can be different depending on the purpose of our State Machine:
// - for example, if our State Machine existed only to deal with character input, we could have only one method on the interface like: "void InputHandler();"
