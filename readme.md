# Unity Project Report

## Introduction

I built the foundation of my project by following these two Kodeco tutorials:  
https://www.kodeco.com/4180726-introduction-to-unity-scripting-part-1

https://www.kodeco.com/4180875-introduction-to-unity-scripting-part-2

---

At the end of this stage:

- Sheep could eat the hay bales thrown by the player.  
- When they ate, a heart appeared on them.  
- For Sheeps that missed the hay or fell down, a counter increased and an X appeared on them.  
- On the screen, there were two separate counters showing:
  - How many Sheeps were fed.  
  - How many fell.  
- Additionally, the windmills in the background were spinning.

---
## My Edits to the Environment
After the tutorial, I wanted to give the game a more lively and charming farm atmosphere.  

For this, I used a few low-poly models from the Unity Asset Store.

**Forest Low Poly Toon Battle Arena Tower Defense Pack**

https://assetstore.unity.com/packages/3d/environments/forest-low-poly-toon-battle-arena-tower-defense-pack-100080  

From this pack:
- I created small islands.  
- I used the River Quad Solo and Water Pixel Solo objects for the flowing river.
- I added grass  

**Farm Environment Asset Pack**

https://assetstore.unity.com/packages/3d/environments/industrial/lite-farm-pack-low-poly-3d-art-by-gridness-243315

From this pack:
- Trees and apples.  
- Farm tools.  
- Barn and silo objects.

---

# My New Mechanics: Wolves and Fireballs
To add more action to the game, I introduced wolves and fireballs.

## Wolf
I got the wolf model from this asset:  

https://assetstore.unity.com/packages/3d/environments/low-poly-nature-collection-129653#content  

## Fireball
- I modeled the fireball entirely myself and wrote its script.  
- I created the visual effect using the fire particle in the ¨Forest Low Poly Toon Battle Arena Tower Defense Pack¨
- I managed its **movement** and **collision control** with my own C# script, derived from the hay bale script.

---

# Final Gameplay Mechanics
The player can now perform two different interactions by pressing the **X key**:

- 🐑 For sheep → Throws a **hay bale**.  
- 🐺 For wolves → Throws a **fireball**.

## Rules:
- 🐑 If a **sheep eats a hay bale** → ❤️ Heart points increase.  
- 🔥 If a **fireball hits a sheep** → The sheep dies.  
- 🐺 If a **wolf is hit by a hay bale** → It speeds up.  
- 🔥 If a **fireball hits a wolf** → It dies.


