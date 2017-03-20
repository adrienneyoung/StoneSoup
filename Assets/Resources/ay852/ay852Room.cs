using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ay852Room : Room {

    public GameObject corgiPrefab;
    public GameObject bonePrefab;
    public GameObject kyubeyPrefab;
    public GameObject ballPrefab;
    public GameObject spikesPrefab;

    public int minCorgis = 0, maxCorgis = 1;
    public int minBones = 2, maxBones = 10;
    public int minKyubey = 1, maxKyubey = 3;
    public int minBall = 2, maxBall = 5;
    public int minSpikes = 4, maxSpikes = 4;

    public override void generateRoom(LevelGenerator ourGenerator, params Dir[] requiredExits)
    {
        //spawn tiles using SpawnTile()
        //Tile.spawnTile(ourGenerator.normalWallPrefab, transform, 1, 1);

        Tile.spawnTile(corgiPrefab, transform, 1, 3);
        Tile.spawnTile(bonePrefab, transform, 1, 5);
        Tile.spawnTile(kyubeyPrefab, transform, 1, 7);
        Tile.spawnTile(kyubeyPrefab, transform, 1, 1);
        Tile.spawnTile(spikesPrefab, transform, 3, 5);
    }
}
