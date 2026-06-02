# Graben_Speed

A fast and addictive 2D platformer created with **Unity** in **C#**. Play as a brave character who must navigate through levels filled with traps, enemies, and exciting challenges!

## Gameplay

### Main Mechanics

- **Dynamic Movement** : Jump, run, and slide through levels with fluid and responsive controls
- **Grappling Hook** : Use your rope to swing across gaps and avoid obstacles
- **Stamina System** : Stamina is consumed when using the grappling hook and special moves
- **Combat** : Shoot at enemies with mouse-aimed shooting
- **Wall Jump** : Bounce from wall to wall to reach difficult-to-access areas

### Game Elements

- **Health System** : Collect healing power-ups to restore your life
- **Collectible Coins** : Gather coins throughout the levels
- **Enemies** : Avoid and fight patrolling enemies
- **Speed Zones** : Accelerate your speed in certain areas
- **Obstacles** : Falling rocks, death zones, and other traps
- **Checkpoints** : Save your progress at checkpoints

### Controls

| Action | Key |
|--------|-----|
| Horizontal Movement | Arrow Keys ← → or A/D |
| Jump | Space |
| Slide | Left Shift |
| Grappling Hook | Left Mouse Click |
| Shoot | Right Mouse Click |
| Pause | Menu |

## Technology

- **Engine** : Unity
- **Language** : C#
- **Type** : 2D Platformer Action Game
- **Platform** : PC (Windows)

## Architecture

### Game Systems

- **PlayerMovement.cs** : Handles all player movements including jumps, slides, and wall jumps
- **GrapplingHook.cs** : Grappling hook system with mouse aiming
- **ShootingPlayer.cs** : Directional shooting mechanic
- **Heal_System.cs** : Health and invincibility management
- **StaminaWheel.cs** : Stamina system for special actions
- **Inventory.cs** : Coins and collectible items management
- **EnemyPatrol.cs** : Enemy patrol system
- **GameOver.cs** : Game Over logic
- **PauseMenu.cs** : Pause menu
- **MainMenu.cs** : Main menu

### Asset Organization

- **Scripts/** : All C# code files
- **Animations/** : Player, enemy, bird, wind animations, etc.
- **Scenes/** : Game levels
- **Prefab/** : Prefabs (enemies, projectiles, etc.)
- **Music/** : Soundtrack
- **Imports/** : Sprites and graphical resources

## Features

- Smooth movement and realistic physics  
- Innovative grappling system  
- Action combat with mouse aiming  
- Health and invincibility system  
- Smart enemies  
- Collectibles and progression  
- Pause menu and settings  
- Checkpoint system  
- Smooth animations  
- Immersive soundtrack  

## Development Notes

The project uses a **singleton** architecture to manage main systems (player, health, inventory, etc.), allowing easy access between classes and simplifying debugging.

Unity's 2D physics system ensures precise movement and realistic interactions with the environment.

## Graphics Credit

Visual assets come mainly from "Pixel Adventure 1" and free resources on indie game platforms.

## License

To be defined

---

**Have fun and enjoy the game!**

