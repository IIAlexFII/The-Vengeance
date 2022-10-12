using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusicLoop : MonoBehaviour
{
    public AudioClip[] audioclip;
    int currentSong;

    // Start is called before the first frame update
    void Start()
    {
        currentSong = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentSong <= audioclip.Length)
        {
            if (gameObject.GetComponent<AudioSource>().isPlaying == false)
            {
                Debug.Log(currentSong);
                gameObject.GetComponent<AudioSource>().clip = audioclip[currentSong];
                gameObject.GetComponent<AudioSource>().Play();
                currentSong++;

            }

        }
        if (currentSong >= audioclip.Length)
        {
            currentSong = 0;
        }

    }
}
