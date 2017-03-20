using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ay852Room : Room {

    public GameObject corgiPrefab;
    public GameObject bonePrefab;
    public GameObject kyubeyPrefab;
    public GameObject ballPrefab;
    public GameObject spikesPrefab;

    public int minCorgis = 1, maxCorgis = 2;
    public int minBones = 1, maxBones = 2;
    public int minKyubeys = 1, maxKyubeys = 2;
    public int minBalls = 2, maxBalls = 5;
    public int minSpikes = 0, maxSpikes = 1;

    public float borderWallProbability = 0.7f;

    public override void generateRoom(LevelGenerator ourGenerator, params Dir[] requiredExits)
    {
        /*
        spawn tiles using SpawnTile()
        Tile.spawnTile(ourGenerator.normalWallPrefab, transform, 1, 1);

        testing tiles
        Tile.spawnTile(corgiPrefab, transform, 1, 3);
        Tile.spawnTile(bonePrefab, transform, 1, 5);
        Tile.spawnTile(kyubeyPrefab, transform, 1, 7);
        Tile.spawnTile(ballPrefab, transform, 1, 1);
        Tile.spawnTile(spikesPrefab, transform, 3, 5);
        */

        generateWalls(ourGenerator, requiredExits);
        
        int numCorgis = Random.Range(minCorgis, maxCorgis + 1);
        int numBones = Random.Range(minBones, maxBones + 1);
        int numKyubeys = Random.Range(minKyubeys, maxKyubeys + 1);
        int numBalls = Random.Range(minBalls, maxBalls + 1);
        int numSpikes = Random.Range(minSpikes, maxSpikes + 1);


        // First, let's make an array keeping track of where we've spawned objects already.
        bool[,] occupiedPositions = new bool[LevelGenerator.ROOM_WIDTH, LevelGenerator.ROOM_HEIGHT];
        for (int x = 0; x < LevelGenerator.ROOM_WIDTH; x++)
        {
            for (int y = 0; y < LevelGenerator.ROOM_HEIGHT; y++)
            {
                if (x == 0 || x == LevelGenerator.ROOM_WIDTH - 1
                    || y == 0 || y == LevelGenerator.ROOM_HEIGHT - 1)
                {
                    // All border zones are occupied.
                    occupiedPositions[x, y] = true;
                }
                else
                {
                    occupiedPositions[x, y] = false;
                }
            }
        }

        // spawn the tiles in random locations
        List<Vector2> possibleSpawnPositions = new List<Vector2>(LevelGenerator.ROOM_WIDTH * LevelGenerator.ROOM_HEIGHT);

        //only spawn these spikes along the sides of the room
        for (int i = 0; i < numBones; i++)
        {
            possibleSpawnPositions.Clear();

            //left side
            int spikesx = 1;
            int spikesy = (int)Random.Range(0, LevelGenerator.ROOM_HEIGHT - 1);

            if (!occupiedPositions[spikesx, spikesy])
            {
                possibleSpawnPositions.Add(new Vector2(spikesx, spikesy));
            }

            //right side
            spikesx = LevelGenerator.ROOM_WIDTH - 2;
            spikesy = (int)Random.Range(0, LevelGenerator.ROOM_HEIGHT - 1);

            if (!occupiedPositions[spikesx, spikesy])
            {
                possibleSpawnPositions.Add(new Vector2(spikesx, spikesy));
            }

            //top side
            spikesx = (int)Random.Range(0, LevelGenerator.ROOM_WIDTH - 1);
            spikesy = LevelGenerator.ROOM_HEIGHT - 2;

            if (!occupiedPositions[spikesx, spikesy])
            {
                possibleSpawnPositions.Add(new Vector2(spikesx, spikesy));
            }

            //bottom side
            spikesx = (int)Random.Range(0, LevelGenerator.ROOM_WIDTH - 1);
            spikesy = 1;

            if (!occupiedPositions[spikesx, spikesy])
            {
                possibleSpawnPositions.Add(new Vector2(spikesx, spikesy));
            }

            if (possibleSpawnPositions.Count > 0)
            {
                Vector2 spawnPos = GlobalFuncs.randElem(possibleSpawnPositions);
                Tile.spawnTile(spikesPrefab, transform, (int)spawnPos.x, (int)spawnPos.y);
                occupiedPositions[(int)spawnPos.x, (int)spawnPos.y] = true;
            }
        }
    

        for (int i = 0; i < numCorgis; i++)
        {
            possibleSpawnPositions.Clear();
            for (int x = 0; x < LevelGenerator.ROOM_WIDTH; x++)
            {
                for (int y = 0; y < LevelGenerator.ROOM_HEIGHT; y++)
                {
                    if (occupiedPositions[x, y])
                    {
                        continue;
                    }
                    possibleSpawnPositions.Add(new Vector2(x, y));
                }
            }
            if (possibleSpawnPositions.Count > 0)
            {
                Vector2 spawnPos = GlobalFuncs.randElem(possibleSpawnPositions);
                Tile.spawnTile(corgiPrefab, transform, (int)spawnPos.x, (int)spawnPos.y);
                occupiedPositions[(int)spawnPos.x, (int)spawnPos.y] = true;
            }
        }

        for (int i = 0; i < numBones; i++)
        {
            possibleSpawnPositions.Clear();
            for (int x = 0; x < LevelGenerator.ROOM_WIDTH; x++)
            {
                for (int y = 0; y < LevelGenerator.ROOM_HEIGHT; y++)
                {
                    if (occupiedPositions[x, y])
                    {
                        continue;
                    }
                    possibleSpawnPositions.Add(new Vector2(x, y));
                }
            }
            if (possibleSpawnPositions.Count > 0)
            {
                Vector2 spawnPos = GlobalFuncs.randElem(possibleSpawnPositions);
                Tile.spawnTile(bonePrefab, transform, (int)spawnPos.x, (int)spawnPos.y);
                occupiedPositions[(int)spawnPos.x, (int)spawnPos.y] = true;
            }
        }

        for (int i = 0; i < numKyubeys; i++)
        {
            possibleSpawnPositions.Clear();
            for (int x = 0; x < LevelGenerator.ROOM_WIDTH; x++)
            {
                for (int y = 0; y < LevelGenerator.ROOM_HEIGHT; y++)
                {
                    if (occupiedPositions[x, y])
                    {
                        continue;
                    }
                    possibleSpawnPositions.Add(new Vector2(x, y));
                }
            }
            if (possibleSpawnPositions.Count > 0)
            {
                Vector2 spawnPos = GlobalFuncs.randElem(possibleSpawnPositions);
                Tile.spawnTile(kyubeyPrefab, transform, (int)spawnPos.x, (int)spawnPos.y);
                occupiedPositions[(int)spawnPos.x, (int)spawnPos.y] = true;
            }
        }

        
        for (int i = 0; i < numBalls; i++)
        {
            possibleSpawnPositions.Clear();
            for (int x = 0; x < LevelGenerator.ROOM_WIDTH; x++)
            {
                for (int y = 0; y < LevelGenerator.ROOM_HEIGHT; y++)
                {
                    if (occupiedPositions[x, y])
                    {
                        continue;
                    }
                    possibleSpawnPositions.Add(new Vector2(x, y));
                }
            }
            if (possibleSpawnPositions.Count > 0)
            {
                Vector2 spawnPos = GlobalFuncs.randElem(possibleSpawnPositions);
                Tile.spawnTile(ballPrefab, transform, (int)spawnPos.x, (int)spawnPos.y);
                occupiedPositions[(int)spawnPos.x, (int)spawnPos.y] = true;
            }
        }
        
        
    }



    protected void generateWalls(LevelGenerator ourGenerator, Dir[] requiredExits)
    {
        // Basically we go over the border and determining where to spawn walls.
        bool[,] wallMap = new bool[LevelGenerator.ROOM_WIDTH, LevelGenerator.ROOM_HEIGHT];
        for (int x = 0; x < LevelGenerator.ROOM_WIDTH; x++)
        {
            for (int y = 0; y < LevelGenerator.ROOM_HEIGHT; y++)
            {
                if (x == 0 || x == LevelGenerator.ROOM_WIDTH - 1
                    || y == 0 || y == LevelGenerator.ROOM_HEIGHT - 1)
                {

                    if (x == LevelGenerator.ROOM_WIDTH / 2
                        && y == LevelGenerator.ROOM_HEIGHT - 1
                        && containsDir(requiredExits, Dir.Up))
                    {
                        wallMap[x, y] = false;
                    }
                    else if (x == LevelGenerator.ROOM_WIDTH - 1
                        && y == LevelGenerator.ROOM_HEIGHT / 2
                        && containsDir(requiredExits, Dir.Right))
                    {
                        wallMap[x, y] = false;
                    }
                    else if (x == LevelGenerator.ROOM_WIDTH / 2
                        && y == 0
                        && containsDir(requiredExits, Dir.Down))
                    {
                        wallMap[x, y] = false;
                    }
                    else if (x == 0
                        && y == LevelGenerator.ROOM_HEIGHT / 2
                        && containsDir(requiredExits, Dir.Left))
                    {
                        wallMap[x, y] = false;
                    }
                    else
                    {
                        wallMap[x, y] = Random.value <= borderWallProbability;
                    }
                    continue;
                }
                wallMap[x, y] = false;
            }
        }

        // Now actually spawn all the walls.
        for (int x = 0; x < LevelGenerator.ROOM_WIDTH; x++)
        {
            for (int y = 0; y < LevelGenerator.ROOM_HEIGHT; y++)
            {
                if (wallMap[x, y])
                {
                    Tile.spawnTile(ourGenerator.normalWallPrefab, transform, x, y);
                }
            }
        }
    }

    protected bool containsDir(Dir[] dirArray, Dir dirToCheck)
    {
        foreach (Dir dir in dirArray)
        {
            if (dirToCheck == dir)
            {
                return true;
            }
        }
        return false;
    }


}
