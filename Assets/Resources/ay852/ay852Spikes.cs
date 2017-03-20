using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//indestructible spikes that damage creatures that collide with it
//they also move back and forth
public class ay852Spikes : Tile {

    protected float counter;
    public float time = 1500f;
    int x = 0;
    int y = 0;

    public override void takeDamage(Tile tileDamagingUs, int damageAmount, DamageType damageType)
    {
        //indestructible
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        //check if we're colliding with a tile
        Tile otherTile = collisionInfo.gameObject.GetComponent<Tile>();
        if (otherTile)
            otherTile.takeDamage(this, 1);
    }

    void Start()
    {
        counter = Random.Range(0, time);
    }

    void Update()
    {
        transform.Rotate(0, 0, 300 * Time.deltaTime);

        if (counter > 0)
        {
            counter -= Time.deltaTime;
        }

        if (counter <= 0)
        {
            x = (int)Random.Range(-10f, 10f);
            x = (int)Random.Range(-10f, 10f);

            moveViaVelocity(new Vector2(x, y), 600f, 100f);

            counter = time;
        }
    }
}
