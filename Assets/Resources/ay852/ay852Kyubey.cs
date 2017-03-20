using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//shoots meat i guess
public class ay852Kyubey : Tile
{

    public AudioClip fireSound;

    /*
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
    }*/
    public Tile ballPrefab;

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
        

        if (tileUsingUs.hasTag(TileTags.Player))
        {
            AudioManager.playAudio(fireSound);
            
                Instantiate(ballPrefab, transform.position + transform.right, Quaternion.Euler(0f, 0f, 0f));
       
        }
    }

    
}
