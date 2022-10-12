using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool gamePaused = false;
    public AudioSource worldAudio;

    [SerializeField] GameObject pauseMenu;

    public GameObject resumeButton, optionsButton, mainMenuButton, exitButton, optionsMenu, pauseMenuText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                Pause();
                worldAudio.Pause();
            }
            else
            {
                Resume();
                resumeButton.SetActive(true);
                mainMenuButton.SetActive(true);
                exitButton.SetActive(true);
                optionsButton.SetActive(true);
                pauseMenuText.SetActive(true);
                optionsMenu.SetActive(false);
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
        worldAudio.Play();
    }

    private void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        gamePaused = true;
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Options()
    {
        resumeButton.SetActive(false);
        mainMenuButton.SetActive(false);
        exitButton.SetActive(false);
        optionsButton.SetActive(false);
        optionsMenu.SetActive(true);
        pauseMenuText.SetActive(false);
    }

    public void Back()
    {
        resumeButton.SetActive(true);
        mainMenuButton.SetActive(true);
        exitButton.SetActive(true);
        optionsButton.SetActive(true);
        optionsMenu.SetActive(false);
        pauseMenuText.SetActive(true);
    }

    /*public void Exit()
    {
        //StartCoroutine(ServerConnection.PostRequest(ServerConnection.BaseAPI + "/updatescore", JsonUtility.ToJson(PlayerData.loginInfo), CloseGame));
    }

    public void CloseGame(string json)
    {
        if (json != null)
        {
            Application.Quit();
        }
    }*/
}
