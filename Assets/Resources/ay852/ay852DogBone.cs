using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a dog bone is consumable and can be held
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

    //people shouldn't eat dog bones but creatures can without problems 
    //player will disappear immediately if they eat/use it
    //they wont lose health though
    public override void useAsItem(Tile tileUsingUs)
    {
        if (_tileHoldingUs != tileUsingUs)
        {
            return;
        }

        if (onTransitionArea())
        {
            return; // Don't allow us to be thrown while we're on a transition area.
        }

        AudioManager.playAudio(chewSound);
        die(); //bone has been consumed

        if (tileUsingUs.hasTag(TileTags.Player))
        {
            AudioManager.playAudio(poofSound);
            tileUsingUs.sprite.color = new Color(1f, 1f, 1f, .05f); //player "disappears"

        }
    }
}