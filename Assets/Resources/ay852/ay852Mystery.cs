using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//mystery meat that makes the
//player  disappear immediately if they eat/use it
//they wont lose health though
public class ay852Mystery : Tile {

    public AudioClip chewSound;
    public AudioClip poofSound;

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

        AudioManager.playAudio(chewSound);
        die(); //bone has been consumed

        if (tileUsingUs.hasTag(TileTags.Player))
        {
            AudioManager.playAudio(poofSound);
            tileUsingUs.sprite.color = new Color(1f, 1f, 1f, .05f); //player "disappears"

        }
    }

}
