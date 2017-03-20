using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//mystery meat that makes the
//player  disappear immediately if they eat/use it
//they wont lose health though
public class ay852Mystery : Tile {
    public float bounceForce = 2000f;

    void Start()
    {
        //destroy myself (projectile) if alive past 10 seconds without hitting anything
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(5f * Time.deltaTime, 0f, 0f);
        //transform.position += new Vector3(5f * Time.deltaTime, 0f, 0f));
    }

    void OnTriggerEnter2D(Collider2D collisionInfo)
    {
        //check if we're colliding with a tile
        Tile otherTile = collisionInfo.gameObject.GetComponent<Tile>();

        if (otherTile)
        {
            if (!otherTile.hasTag(TileTags.Player))
            {
                otherTile.takeDamage(this, 1);
                Vector2 dirToBounce = ((Vector2)(otherTile.transform.position - transform.position)).normalized;
                otherTile.addForce(dirToBounce * bounceForce);
                die(); 
            }
        }
    }

}
