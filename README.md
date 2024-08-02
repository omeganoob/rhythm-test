Structure descriptions:

- Assets: All game file, such as C# scripts, image, audio,....
- Anim: Animatior and animation clips for UI and tutorial hand
- Materials: In this project, i have only one material for the particle system
- Scripts: Contains c# scripts for game objects and game managers
- Songs: Scriptable objects for songs
- Sprites: graphics assets for game and UI

Main Folder struture:
```
Assets/
├── Anim/
│   ├── HandAnim.controller
|   ├── Hand.anim
│   ├──PulseText.controller
|   └── Pulse.anim
├── Materials/
│   └── Particle.mat
├── Prefabs/
|    ├── Tile Button.prefab
│    └── HitSpark.prefab
├── Scripts/
|    └── audio/
│          └── a_how-do-you-like-that--cut_st.mp3
├── Scripts/
│   ├── BeatManager.cs
│   ├── EHitPerform.cs
│   ├── GameManager.cs
│   ├── IClick.cs
│   ├── ELimitLine.cs
│   ├── MoveDown.cs
│   ├── MusicTile.cs
│   ├── Song.cs
│   ├── StartNote.cs
│   ├── TileSpawner.cs
│   └── TouchManager.cs
├── Songs/
│   └── howyoulikethat.asset
├── Sprites/
...
```

Possible Improvements:
- Improve performance as the game has pretty poor performance for its scope.
- Improve sync between notes and the song.
- Code structure can be rebuilt and improved.
- Implement long notes that need to be held down.
