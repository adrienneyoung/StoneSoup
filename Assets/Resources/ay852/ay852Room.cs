using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ay852Room : Room {

    public GameObject corgiPrefab;

    public int minCorgis = 0, maxCorgis = 1;

    //we can access the wall prefabs by passing in levelgenerator
    //something about Dir[]?

    public override void generateRoom(LevelGenerator ourGenerator, params Dir[] requiredExits)
    {
        //spawn tiles using SpawnTile()
        //Tile.spawnTile(ourGenerator.normalWallPrefab, transform, 1, 1);

        //create prefab and add box collider 2d and tile script on it. 
        //also set a tag and zap to death effect and own sound to death sfx
        Tile.spawnTile(corgiPrefab, transform, 1, 3);

        //create sprite in photoshop and refer to other sprites to set the sprite size

        //to create ur own tile, make a script for it
    }
}
