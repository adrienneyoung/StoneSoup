using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a dog bone is consumable and can be held
//creatures who eat it (besides the player) will gain 1 health
//it can't be damaged by explosive or normal damage
//the player should drop the bone near the dog as an offering
//the dog will keep bouncing away the player until the dog is fed
public class ay852DogBone : Tile
{

    public AudioClip chewSound;
    public AudioClip poofSound;

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        //check if we're colliding with a tile
        Tile otherTile = collisionInfo.gameObject.GetComponent<Tile>();

        if (otherTile)
        {
            if (otherTile.hasTag(TileTags.Creature) && !otherTile.hasTag(TileTags.Player))
            {
                //gives the creature 1 more health
                otherTile.health++;
                AudioManager.playAudio(chewSound);
                die(); //bone has been consumed
            }
        }
    }

    
}