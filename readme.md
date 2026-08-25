# Hangman

By Group 5

## Functions, Objects, and Variables

### Variables

| Name      | Type     | Desc                                                            |
| --------- | -------- | --------------------------------------------------------------- |
| MAX_LEVEL | int      | The number of levels player<br>needs to clear before<br>winning |
| WORD_LIST | string[] | The list of words to be used<br>for hangman                     |

### Objects

| Name   | Variables                                                           | Functions                                                                                                                | Desc                                                                                              |
| ------ | ------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------------------- |
| Player | string username<br>int hp<br>int currentLevel<br>int points (Extra) | getUsername()<br>getHp()<br>getCurrentLevel()<br>getPoints()<br>setUsername()<br>setHp()<br>setUsername()<br>setPoints() | The main player<br>object created at the<br>start of the game,<br>and passed to most<br>functions |

### Functions

| Name        | Input       | Output       | Desc                                                  |
| ----------- | ----------- | ------------ | ----------------------------------------------------- |
| StartofGame | void        | Player       | Start screen, player<br>initialization                |
| Hangman     | string word | bool wonGame | The main gameplay,<br>consists of guessing<br>letters |

| Name         | Input         | Output | Desc              |
| ------------ | ------------- | ------ | ----------------- |
| EndingScreen | Player player | void   | The ending screen |

## Overall Structure

Start of Game -> Gameplay Loop -> Ending Screen

### Start of Game

The start of game initializes the main player object as well as give some expository dialog abt the story or smth.

The components of this will be placed in a function StartofGame()

The function will return an instance of a Player object, which will be used to keep track of the player’s stats between levels

### Gameplay Loop

#### Structure

|                          |      |                       |
| ------------------------ | ---- | --------------------- |
| Check isGameOver == true | Yes➡ | EndingScreen()        |
| ⬇No                      |      |                       |
| Hangman()                |      |                       |
| ⬇                        |      |                       |
| -1 hp if loss            |      |                       |
| ⬇                        |      |                       |
| Check if game over       | Yes➡ | set isGameOver = true |
| ⬇                        |      |                       |
| Back to top (Loop again) |      |                       |

- A variable isGameOver is set before the loop
  1.  The loop checks this variable every iteration.

  2.  The Hangman() functions allows the player to play a game and return a bool representing if the player won the game. The player will lose 1hp if they lose the match, and +1 to currentLevel if they won the game.
      - a. Hangman() takes in a word as its parameter, the word can be accessed from WORD_LIST , either by taking a random word, or a word based on the current level of the user.

3. Game over occurs if the player’s life is 0 or their current level is equal to the <u>MAX_LEVEL</u> . If so, set isGameOver = true

4. Repeat the loop

### Hangman()

The main gameplay function. Takes in the word as a string, and returns a bool wonGame.

### EndingScreen()

The ending screen of the game. Checks if the user's hp is more than 0. If so, display the victory screen, if not, display the defeat screen. Takes in the player object
