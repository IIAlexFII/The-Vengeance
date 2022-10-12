using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Sprite spriteEnter, spriteExit;

    public GameObject playButton, optionsButton, exitButton, backButton;

    //Methods to change the Image sprite when mouse enters on buttons
    public void SpriteOnEnterPlay()
    {
        playButton.GetComponent<Image>().sprite = spriteEnter;
    }

    public void SpriteOnEnterOptions()
    {
        optionsButton.GetComponent<Image>().sprite = spriteEnter;
    }

    public void SpriteOnEnterExit()
    {
        exitButton.GetComponent<Image>().sprite = spriteEnter;
    }

    public void SpriteOnEnterBack()
    {
        backButton.GetComponent<Image>().sprite = spriteEnter;
    }

    //Methods to change the Image sprite when mouse exits on buttons
    public void SpriteOnExitPlay()
    {
        playButton.GetComponent<Image>().sprite = spriteExit;
    }

    public void SpriteOnExitOptions()
    {
        optionsButton.GetComponent<Image>().sprite = spriteExit;
    }

    public void SpriteOnExitExit()
    {
        exitButton.GetComponent<Image>().sprite = spriteExit;
    }

    public void SpriteOnExitBack()
    {
        backButton.GetComponent<Image>().sprite = spriteExit;
    }

}
