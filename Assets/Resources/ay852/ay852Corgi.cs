using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ay852Corgi : Tile {

    //the corgi will bounce the player away if they didn't give the corgi food

    bool ateFood;
    float bounceForce = 1500f;
    AudioSource bark;

    void Start()
    {
        bark = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D (Collision2D collisionInfo) //Collider2D is for OnTriggerEnter2D
    {
        //check if we're colliding with a tile
        Tile otherTile = collisionInfo.gameObject.GetComponent<Tile>();

        if (otherTile) 
        {
            if(otherTile.hasTag(TileTags.Weapon)) //corgi can be interacted with if it picked up food
            {
                ateFood = true;
                addTag(TileTags.CanBeHeld); //how to make play ride corgi?
            }

            if (otherTile.hasTag(TileTags.Player))
            {
                if (!ateFood) //bouncing the player away if the corgi didn't get food
                {
                    //make sure the position is vector2 by casting it
                    Vector2 dirToBounce = ((Vector2)(otherTile.transform.position - transform.position)).normalized;
                    otherTile.addForce(dirToBounce * bounceForce);
                }
            }

            //bark bark
            bark.Play();
        }
    }
}
