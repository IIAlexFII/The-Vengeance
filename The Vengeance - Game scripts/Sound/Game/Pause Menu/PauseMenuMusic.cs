using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuMusic : MonoBehaviour
{
    private PauseMenu pauseMenu;
    private bool musicOn;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
        musicOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.gamePaused == true && musicOn == false)
        {
            musicOn = true;
            gameObject.GetComponent<AudioSource>().Play();
        }

        if(pauseMenu.gamePaused == false)
        {
            musicOn = false;
            gameObject.GetComponent<AudioSource>().Stop();
        }
    }
}
