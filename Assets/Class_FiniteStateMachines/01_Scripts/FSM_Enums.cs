
// this script only exists as a "enums" repository
// we can use it to store every enum that needs to be globally accessed in the game

// "GameState" enum, defines our game states, them being:
// 1. Menu
// 2. Game
// 3. GameOver
// the "None" only exists in case we need to initialize a "null" state (one that doesn't do anything):
// - for example: at the beginning of the game
public enum GameState
{
    None = 0,
    Menu = 1,
    Game = 2,
    GameOver = 3
}
