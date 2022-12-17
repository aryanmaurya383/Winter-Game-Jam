using UnityEngine;
using UnityEngine.SceneManagement;

public class FadingAnimation : MonoBehaviour
{
    public Animator animator;
    public static string newSceneName;
    // Start is called before the first frame update
    void Start()
    {
        newSceneName = "MainGame";
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerSearching.fadeToNewScene)
        {
            PlayerSearching.fadeToNewScene = false;
            FadeToLevel();
        }
    }
    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(newSceneName);
    }
}
