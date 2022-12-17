using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Resume();
        }
    }
    public  void Pause()
    {
        PlayerMovement.isPaused = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        PlayerMovement.isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        FadingAnimation.newSceneName = "HomeScreen";
        PlayerSearching.fadeToNewScene = true;
        //SceneManager.LoadScene("HomeScreen");
    }

    public void Help()
    {
        Time.timeScale = 1f;
        FadingAnimation.newSceneName = "HelpScene";
        PlayerSearching.fadeToNewScene = true;
        //SceneManager.LoadScene("HelpScene");
    }
}
