# Kitchen Chaos

A Unity 3D cooking game by Jan Ali Hassan, built while following [Code Monkey's Kitchen Chaos course](https://unitycodemonkey.com/kitchenchaoscourse.php). You grab ingredients, chop and fry them, plate the orders that come in and deliver them before the round clock runs out.

> **Credit:** the game design, the art, models and sounds in `Assets/_Assets`, and the overall architecture come from Code Monkey's course. I wrote the code by working through it, as practice in event-driven, clean C# architecture. This is a learning project, not an original design.

![Kitchen Chaos gameplay screenshot](https://janalihassan.dev/images/The_Kitchen_Chaos.png)

▶️ [Watch the gameplay video](https://janalihassan.dev/videos/The-Kitchen-Chaos.mp4) · 🌐 [More of my games at janalihassan.dev](https://janalihassan.dev/#library) · 💼 [LinkedIn post](https://lnkd.in/p/dncAQqN5)

## Features

- **Ingredient flow through counters:** container counters hand out bread, cabbage, tomato, cheese and raw patties. You chop on cutting counters, fry on the stove, put things down on clear counters and throw them away at the trash.
- **Stove states:** a patty goes Idle → Frying → Fried → Burned. When it gets close to burning, a warning icon pops up and the stove starts flashing.
- **Plates and recipes:** plates spawn on the plate counter, up to 4 at a time. A plate takes each valid ingredient once, and the delivery counter checks it against four recipes: Burger, Cheese Burger, MEGA Burger and Salad.
- **Order queue:** a new order shows up every 4 seconds, with at most 4 waiting. Each delivery pops up a success or failed message.
- **Round flow:** the game waits for you to press Interact, counts down from 3, then plays a timed round with a clock UI. At the end, a game over screen shows how many recipes you delivered.
- **Rebindable controls:** keyboard bindings can be changed in the options menu and are saved to `PlayerPrefs`. The defaults are WASD or the arrow keys to move, E to interact, F to cut and Escape to pause.
- **Pause and options menus:** you can resume, go back to the main menu, and step through sound-effect and music volume, which is also saved.
- **Scene loading:** Main Menu → Loading → Game, through a small static `Loader`.

## Built with

- Unity **2022.3.52f1** (LTS), C#
- Universal Render Pipeline 14.0.11, with a global post-processing volume and a Shader Graph shader (`Assets/Shaders/MovingVisual.shadergraph`)
- Input System 1.11.2 (generated `PlayerInputAction` class, interactive rebinding)
- TextMeshPro for UI text
- ScriptableObjects for all the game data: ingredients, cutting, frying and burning recipes, the recipe list and audio clip references

## Key scripts

All the scripts are in `Assets/Scripts/`.

| Script | What it does |
| --- | --- |
| `KitchenGameManager.cs` | Singleton state machine (WaitingToStart, CountdownToStart, GamePlaying, GameOver), round timer and pause. It fires `OnStateChanged`, `OnGamePause` and `OnGameUnPause`. |
| `Player.cs` | Capsule-cast movement that slides along walls, a raycast to pick the counter you're facing, and holding one kitchen object |
| `GameInput.cs` | Wraps the Input System actions as C# events and handles rebinding and saving bindings |
| `Counters/BaseCounter.cs` | Base class for every counter, with virtual `Interact` / `InteractAlternate` |
| `Counters/CuttingCounter.cs`, `StoveCounter.cs`, `PlatesCounter.cs`, `DeliveryCounter.cs`, `ContainerCounter.cs`, `ClearCounter.cs`, `TrashCounter.cs` | The counter types. Each one overrides the interaction logic. |
| `IkitchenObjectParent.cs` | Interface shared by the player and the counters, so any of them can hold a kitchen object |
| `IHasProgress.cs` | Interface for anything with a progress bar (cutting, frying). A single `ProgressBarUI` listens to it. |
| `KitchenObjects.cs` / `PlateKitchenObject.cs` | Spawning and reparenting kitchen objects. A plate is a subclass that collects ingredients. |
| `DeliveryManager.cs` | Spawns orders, matches the plate you deliver against waiting recipes, counts successful deliveries |
| `SoundManager.cs` / `MusicManager.cs` | Play sounds in response to game events (chop, pickup, drop, trash, delivery), with volume settings saved |
| `ResetStaticDataManager.cs` | Clears static events when a scene loads, so listeners from an earlier play session don't stick around |
| `UI/*` | Order list, plate icons, countdown, clock, tutorial, pause, options and game over screens. Each one subscribes to manager events. |

## Running the project

1. Clone the repo and open it in Unity Hub with **Unity 2022.3.52f1**.
2. Open `Assets/Scenes/MainMenuScene.unity`, the first scene in Build Settings.
3. Press Play, then click Play in the menu. In the game scene, press E to start the countdown.

The scenes in Build Settings are `MainMenuScene`, `GameScene` and `LoadingScene`.

## Author

Jan Ali Hassan · [Portfolio](https://janalihassan.dev) · [LinkedIn](https://www.linkedin.com/in/janalihassan) · [GitHub](https://github.com/janalihassan)
