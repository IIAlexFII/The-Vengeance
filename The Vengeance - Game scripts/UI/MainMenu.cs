using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu, mainMenu;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void exitbtn()
    {
        Application.Quit();
        Debug.Log("Closed");
    }

    public void playbtn()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Back()
    {
        optionsMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);
    }
}
