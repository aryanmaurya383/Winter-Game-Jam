using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
public class GameOverScript : MonoBehaviour
{
    public TextMeshProUGUI score;
    

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + ((int)ScoreManager.finalScoreValue).ToString();
        
    }

    public void Retry()
    {
        FadingAnimation.newSceneName = "MainGame";
        PlayerSearching.fadeToNewScene = true;
        //SceneManager.LoadScene("MainGame");
        Time.timeScale = 1f;
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    public void Home()
    {
        Time.timeScale = 1f;
        FadingAnimation.newSceneName = "HomeScreen";
        PlayerSearching.fadeToNewScene = true;
        //SceneManager.LoadScene("HomeScreen");
    }
}
