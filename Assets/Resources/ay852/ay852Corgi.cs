using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the corgi will bounce the player away if they didn't give the corgi food
public class ay852Corgi : Tile {

    public bool ateFood = false;
    public float bounceForce = 1500f;
    public AudioClip barkSound;
    public AudioClip lickSound;
    Vector3 point = new Vector3(0, 2, 0);

    void OnCollisionEnter2D (Collision2D collisionInfo) //Collider2D is for OnTriggerEnter2D
    {
        //check if we're colliding with a tile
        Tile otherTile = collisionInfo.gameObject.GetComponent<Tile>();

        if (otherTile) 
        {
            if (otherTile.hasTag(TileTags.Player))
            {
                if (!ateFood) //bounce the player away if the corgi didn't get food
                {
                    //make sure the position is vector2 by casting it
                    Vector2 dirToBounce = ((Vector2)(otherTile.transform.position - transform.position)).normalized;
                    otherTile.addForce(dirToBounce * bounceForce);

                    //angry bark
                    AudioManager.playAudio(barkSound);
                }

                else if (ateFood)
                {
                    //what will happen if the player collides with the fed corgi?
                   AudioManager.playAudio(lickSound);

                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        //check if we're colliding with a tile
        Tile otherTile = collisionInfo.gameObject.GetComponent<Tile>();

        if (otherTile)
        {
            if (otherTile.hasTag(TileTags.Consumable))
            {
                ateFood = true;
            }
        }
    }

    void Update()
    {
        if(ateFood == true)
        {
            sprite.color = Color.blue;
            //transform.RotateAround(point, Vector3.up, 20f * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        _sprite.flipX = true;
    }
}
