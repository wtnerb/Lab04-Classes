


# TicTacToe with Classes

## Overview
Play Tic Tac Toe in the console.

## Use

It will start by prompting for username and symbol for each player. Follow the prompts. Usernames can be only one word (numbers OK) and symbols can only be a single capital letter. Once both players' information has been provided, the game will begin.

If player 1 input "Brent" as their name, the output should look like this at the start of the game:
```
It is now Brent's turn.
|1||2||3|
|4||5||6|
|7||8||9|
Please provide desired square
```

Player one (Brent) would then input a number 1 through 9 as the desired play square. As an example, Brent put in 6. Because Brent chose 'N' as his symbol, the board then showed:

```
It is now Travis's turn.
|1||2||3|
|4||5||N|
|7||8||9|
Please provide desired square
```

The game will automatically notice a win or draw and end the game.

## Architecture
The Board class holds the board interactive parts of the program. The Player class makes players with a matching name and symbol. The Program itself holds interaction with the user and the console, as well as game flow logic. NOTE: Ideally, the win detection method would be moved into the board class, but the tests for it had been written assuming it's current place and because of time constraints refactoring those tests was deemed not doable for initial release.

## Sources
https://docs.microsoft.com/en-us/ proved vital to the building of this project.

## Change log

2018-03-23 0.9 released. Things were not functional yet, but the skeleton was there.

2018-03-23 1.0 full release. Game is functional and MVP is reached.

