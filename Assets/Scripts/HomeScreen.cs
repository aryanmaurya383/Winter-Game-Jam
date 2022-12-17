using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeScreen : MonoBehaviour
{
    public void Play()
    {
        FadingAnimation.newSceneName = "MainGame";
        PlayerSearching.fadeToNewScene = true;
        Time.timeScale = 1f;
        //SceneManager.LoadScene("MainGame");
    }

    public void Help()
    {
        FadingAnimation.newSceneName = "HelpScene";
        PlayerSearching.fadeToNewScene = true;
        //SceneManager.LoadScene("HelpScene");
        Debug.Log("Help pressed");
      
    }

    public void Exit()
    {
        
        Application.Quit();
    }
}
