using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the corgi will bounce the player away if they didn't give the corgi food
//will become friendly and follow the player around after the corgi gets food
//may even take some enemy hits on the player's behalf
public class ay852Corgi : Tile {

    public bool ateFood = false;
    public float bounceForce = 1500f;
    public AudioClip barkSound;
    public AudioClip lickSound;

    //see where the player is so the corgi can move towards them
    protected float counter;
    public float time = 0.2f;
    public float searchRadius = 16f;

    void Start()
    {
        counter = Random.Range(0, time);
    }

    void Update()
    {
        //look for food and then move towards it to eat it
        if(!ateFood)
        {
            if (counter > 0)
            {
                counter -= Time.deltaTime;
            }

            if (counter <= 0)
            {
                //area to look for food
                Collider2D[] maybeColliders = Physics2D.OverlapCircleAll(transform.position, searchRadius);
                foreach (Collider2D maybeCollider in maybeColliders)
                {
                    Tile tile = maybeCollider.GetComponent<Tile>();
                    if (tile != null && tile.hasTag(TileTags.Consumable))
                    {
                        Vector2 directionToPlayer = ((Vector2)tile.transform.position - (Vector2)transform.position);
                        moveViaVelocity(directionToPlayer.normalized, 200f, 60f);

                        if (directionToPlayer.normalized.x >= 0)
                            sprite.flipX = false;
                        else
                            sprite.flipX = true;
                    }
                }

                counter = time;
            }
        }

        //follow the player around as their companion
        else if (ateFood)
        {
            if (counter > 0)
            {
                counter -= Time.deltaTime;
            }

            if (counter <= 0)
            {
                //area to look for the player
                Collider2D[] maybeColliders = Physics2D.OverlapCircleAll(transform.position, searchRadius);
                foreach (Collider2D maybeCollider in maybeColliders)
                {
                    Tile tile = maybeCollider.GetComponent<Tile>();
                    if (tile != null && tile.hasTag(TileTags.Player))
                    {
                        Vector2 directionToPlayer = ((Vector2)tile.transform.position - (Vector2)transform.position);
                        moveViaVelocity(directionToPlayer.normalized, 200f, 60f);

                        if (directionToPlayer.normalized.x >= 0)
                            sprite.flipX = false;
                        else
                            sprite.flipX = true;
                    }
                }

                counter = time;
            }
        }
        
    }

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
                    //if the player was invisible, turn the player visible again
                   AudioManager.playAudio(lickSound);
                    otherTile.sprite.color = new Color(1f, 1f, 1f, 1f);
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
                addTag(TileTags.Friendly);
            }
        }
    }
}
