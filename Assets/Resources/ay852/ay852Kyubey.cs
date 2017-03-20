using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a "cute" cat-thing
//but its actually a trap for friendlies and players
public class ay852Kyubey : Tile
{

    public AudioClip fireSound;

    void OnCollisionEnter2D(Collision2D collisionInfo) //Collider2D is for OnTriggerEnter2D
    {
        //check if we're colliding with a tile
        Tile otherTile = collisionInfo.gameObject.GetComponent<Tile>();

        if (otherTile)
        {
            if (otherTile.hasTag(TileTags.Player) || otherTile.hasTag(TileTags.Friendly))
            {
                otherTile.takeDamage(this, 3);
                sprite.color = Color.red;
                AudioManager.playAudio(fireSound);
            }
        }
    }
}
