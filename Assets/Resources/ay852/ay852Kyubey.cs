using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is a cat-thing that can collect objects and then fire them as projectiles
public class ay852Kyubey : Tile {

    public AudioClip fireSound;

    //people shouldn't eat dog bones but creatures can without problems 
    //player will disappear immediately if they eat/use it
    //they wont lose health though
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

        AudioManager.playAudio(fireSound);
        tileUsingUs.sprite.color = new Color(1f, 1f, 1f, .05f); //player "disappears"
    }

}
