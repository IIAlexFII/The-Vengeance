using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManagerPM : MonoBehaviour
{
    public Sprite spriteEnter, spriteExit;

    public GameObject resumeButton, optionsButton, mainMenuButton, exitButton, backButton;

    //Methods to change the Image sprite when mouse enters on buttons
    public void SpriteOnEnterResumeButton()
    {
        resumeButton.GetComponent<Image>().sprite = spriteEnter;
    }

    public void SpriteOnEnterMainMenuButton()
    {
        mainMenuButton.GetComponent<Image>().sprite = spriteEnter;
    }

    public void SpriteOnEnterExit()
    {
        exitButton.GetComponent<Image>().sprite = spriteEnter;
    }

    public void SpriteOnEnterOptions()
    {
        optionsButton.GetComponent<Image>().sprite = spriteEnter;
    }

    public void SpriteOnEnterBack()
    {
        backButton.GetComponent<Image>().sprite = spriteEnter;
    }

    //Methods to change the Image sprite when mouse exits on buttons
    public void SpriteOnExitResumeButton()
    {
        resumeButton.GetComponent<Image>().sprite = spriteExit;
    }

    public void SpriteOnExitMainMenuButton()
    {
        mainMenuButton.GetComponent<Image>().sprite = spriteExit;
    }

    public void SpriteOnExitExit()
    {
        exitButton.GetComponent<Image>().sprite = spriteExit;
    }

    public void SpriteOnExitOptions()
    {
        optionsButton.GetComponent<Image>().sprite = spriteExit;
    }

    public void SpriteOnExitBack()
    {
        backButton.GetComponent<Image>().sprite = spriteExit;
    }
}
