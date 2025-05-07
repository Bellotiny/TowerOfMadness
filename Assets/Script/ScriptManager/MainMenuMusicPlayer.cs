using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusicPlayer : MonoBehaviour
{
   void Start()
    {
        GameObject levelMusic = GameObject.FindWithTag("LevelMusicPlayer");
        if (levelMusic != null)
        {
            Destroy(levelMusic);
        }

        gameObject.tag = "MusicPlayer";

        GetComponent<AudioSource>().Play();
    }
}
