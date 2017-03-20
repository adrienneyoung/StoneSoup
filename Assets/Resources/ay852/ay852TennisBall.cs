using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ay852TennisBall : Tile {

    //if a creature collides with us, bounce it away

    public float bounceForce = 2000f;

    void OnCollisionEnter2D(Collision2D collisionInfo) //not collider2d! that's for ontriggerenter2d
    {
        //check if we're colliding with a tile
        Tile otherTile = collisionInfo.gameObject.GetComponent<Tile>();
        if (otherTile) //if(otherTile != null)
        {
            //check for tags (can't remove or add tags to other objects but can do it to urself) 
            //if u don't want certain things to bounce

            //normalized usually takes vector3 (?) so make sure the position is vector2 by casting it
            Vector2 dirToBounce = ((Vector2)(otherTile.transform.position - transform.position)).normalized;
            otherTile.addForce(dirToBounce * bounceForce);
        }
    }
}
