
// SINGLETON EXAMPLE //
// - Not only this works as Singleton, but also a Manager for all kinds of variables or references that should be accessible throughout the game
// - So instead of having several Singletons (one for each important reference), which would lead to a confusing web of scripts getting values from each other
// - We have one Global Singleton which shares those values to whoever needs it. It's more centralized and more organized

public class FSM_Singleton_Example_GlobalVarsManager
{
    #region Singleton
    
    // Static variable
    // this means we'll have an "Instance" variable which will be accessible from anywhere in the game
    private static FSM_Singleton_Example_GlobalVarsManager instance;
    public static FSM_Singleton_Example_GlobalVarsManager Instance
    {
        get
        {
            // if our private (local) instance doesn't exist...
            if (instance == null)
            {
                // ...we create a new instance of our singleton class
                new FSM_Singleton_Example_GlobalVarsManager();
            }
            return instance;
        }
    }

    // Constructor (special method that runs once when an instance of a class is created)
    public FSM_Singleton_Example_GlobalVarsManager()
    {
        // we check again if our instance already exists...
        if (instance != null)
        {
            // ... if it does already exist, we get out of the constructor (we shouldn't create another)...
            return;
        }

        // ...if there's no instance we set it as our recently created instance
        instance = this;
    }
    #endregion

    // we're using this script as a "Holder" of references for important GameObjects, variables or Classes,
    // and as such, we should store them in a way they can be accessed easily when using our Singleton
    // so we create a a public reference "GameManager" of this script, based of the value of our "private static" variable for the same script
    // because, since we only have one instance of our singleton, we want to make sure we also only have a unique static value of our reference
    // NOTE: This "formula" should be replicated to every "important" script or variable we want to acess throughout the game
    private static FSM_Singleton_Example_GameManager gameManager;
    public FSM_Singleton_Example_GameManager GameManager
    {
        get
        {
            // when we need to access the Game Manager reference we return our private variable
            return gameManager;
        }
        set
        {
            // by default this reference won't have any value, so we need to set its reference at the beginning of the game (or as soon as possible)
            // we do that, by assigning it the "value" on the corresponding class (see the "FSM_Singleton_Example_GameMaanger" script)
            gameManager = value;
        }
    }

}
