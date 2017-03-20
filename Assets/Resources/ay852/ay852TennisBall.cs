using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//bounces tiles away and also hurts them
//doesn't hurt datable things
public class ay852TennisBall : Tile {

    public float bounceForce = 2000f;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        //check if we're colliding with a tile
        Tile otherTile = collisionInfo.gameObject.GetComponent<Tile>();
        if (otherTile) 
        {
            if (!otherTile.hasTag(TileTags.Wall))
            {
                Vector2 dirToBounce = ((Vector2)(otherTile.transform.position - transform.position)).normalized;
                otherTile.addForce(dirToBounce * bounceForce);
                otherTile.takeDamage(this, 1);
            }
        }
    }
}
