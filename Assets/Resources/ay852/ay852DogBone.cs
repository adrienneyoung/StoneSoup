using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ay852DogBone : Tile
{
    //a dog bone is consumable and can be held
    public AudioClip chewSound;

    // Keep track of whether we're in the air and whether we were JUST thrown
    protected bool ateBone = false;
    protected float afterEatingCounter;
    public float afterEatingTime = 0.2f;

    //can be damaged by normal and explosive damage
    public override void takeDamage(Tile tileDamagingUs, int amount, DamageType damageType)
    {
        if (damageType == DamageType.Explosive || damageType == DamageType.Normal)
        {
            base.takeDamage(tileDamagingUs, amount, damageType);
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        //check if we're colliding with a tile
        Tile otherTile = collisionInfo.gameObject.GetComponent<Tile>();

        if (otherTile)
        {
            if (otherTile.hasTag(TileTags.Creature))
            {
                //gives the creature 1 more health
                otherTile.health++;
                AudioManager.playAudio(chewSound);
                die(); //bone has been consumed
            }
        }
    }

    //people shouldn't eat dog bones.... 
    //player will get food poisoning immediately if they eat/use it
    //they wont lose health, but they'll get dizzy
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
        tileUsingUs.sprite.color = Color.green; //show that the player is sick

        afterEatingCounter = afterEatingTime;

    }

    //set down the bone near the dog as an offering to it
    //trigger is now false so the dog can collide with it and eat it

}