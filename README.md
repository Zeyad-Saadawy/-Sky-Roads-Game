# Sky Roads Game

Sky Roads is an endless runner-style game inspired by the classic "Sky Roads." This game challenges players to navigate through an infinite path while avoiding obstacles, managing speed, and keeping an eye on fuel. The project is developed using Unity and C#.

## Gameplay Overview

In Sky Roads, the player controls a sphere that moves forward automatically along a divided path with three lanes. The player can switch lanes and jump to avoid obstacles and gaps. The objective is to survive as long as possible while scoring points, which accumulate over time.

## Game Features

### Movement
- **Automatic Forward Movement**: The sphere moves forward on its own.
- **Lane Switching**: The player can switch lanes discretely using arrow keys or "A" and "D".
- **Jumping**: The player can jump to avoid obstacles and gaps but cannot double jump.

### Item Generation
- **Randomized Tiles**: Lanes contain various tiles, including Normal, Burning, Supplies, Boost, Sticky, and Empty tiles.
- **Obstacles**: Randomly placed obstacles challenge players to react and maneuver.

### Scoring
- **Score**: Based on the time survived in seconds, displayed on the screen.

### Speed Levels
- **Normal and High Speed**: Players can switch between Normal and High speeds by encountering specific tiles (Boost or Sticky).

### Fuel Management
- **Fuel Depletion and Refill**: Fuel decreases over time and depletes faster on specific tiles. Refill occurs on specific tiles.

## Tile Types

- **Normal Tile**: Standard tile with no effect.
- **Burning Tile**: Causes rapid fuel depletion.
- **Supplies Tile**: Refills fuel to maximum.
- **Boost Tile**: Doubles player speed.
- **Sticky Tile**: Resets speed to normal.
- **Empty Tile**: Gaps that lead to a game over if the player falls.

## Game Controls

- **Left/Right Arrows or A/D**: Move left or right.
- **Space Bar**: Jump.
- **Escape**: Pause and resume the game.

## UI Screens

- **Title Screen**: Start the game, view controls, and exit.
- **HUD**: Displays current fuel level, speed, and score.
- **Pause Screen**: Resume, restart, or exit to the main menu.
- **Game Over Screen**: Displays final score with options to restart or return to the main menu.

## Sound Design

- **Sound Effects**: Various audio cues for tile interactions and obstacle collisions.
- **Soundtracks**: Background music during gameplay and ambient sounds for menu screens.

## Optional Cheats

These cheats can be used to aid testing:
- **Invincibility**: Prevents damage from obstacles.
- **Half Speed**: Reduces player speed.
- **Full Fuel**: Refills fuel instantly.

## Development Setup

1. **Software Requirements**: Unity (latest stable version recommended), C#.
2. **Installation**:
   - Clone the repository.
   - Open the project in Unity and install any required packages.

## How to Play

1. Use the controls to avoid obstacles, collect boosts, and survive as long as possible.
2. Monitor fuel and avoid burning tiles to prevent rapid depletion.
3. Aim to achieve a high score by covering the longest distance.

## Credits

- **External Resources**: Sound and music assets (listed in-game).
