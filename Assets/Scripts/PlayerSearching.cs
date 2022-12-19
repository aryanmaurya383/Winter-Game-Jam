using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSearching : MonoBehaviour
{
    public static bool notHidden;
    public static bool isDead;
    public static bool colourNotMatching;
    public AudioSource gameOverSound;
    public Animator animator;
    public bool alreadyPlayed;
    private float delayTime = 0;
    public static bool fadeToNewScene;
    

    // Start is called before the first frame update
    void Start()
    {
        fadeToNewScene = false;
        alreadyPlayed = false;
        isDead = false;
        notHidden = true;
        colourNotMatching = true;
        animator.SetBool("IsDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.falling)
        {

            Debug.Log("Game Over");
            isDead = true;
            PlayerMovement.falling = false;
            FadingAnimation.newSceneName = "GameOverScene";
            animator.enabled = true;
            animator.SetBool("IsDead", true);
        }
        if(isDead)
        {
            if(delayTime > 0.8f)
            {
                fadeToNewScene = true;
                delayTime = 0;
//                isDead = false;
            }
            delayTime += Time.deltaTime;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HidingTrigger"))
        {
            notHidden = false;
        }
        if (collision.CompareTag("Stars"))
        {
            ScoreManager.starsCollected += 15;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HidingTrigger"))
        {
            notHidden = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if  (collision.CompareTag("SearchingLight") && (notHidden || colourNotMatching || (PlayerMovement.player_velocity.x>0.01) || (PlayerMovement.player_velocity.y>0.01)))
        {
            
            Debug.Log("Game Over");
            isDead = true;
            PlayerMovement.falling = false;
            FadingAnimation.newSceneName = "GameOverScene";
            animator.enabled = true;
            animator.SetBool("IsDead", true);
        }
    }
    public void GameOverSound()
    {
        if(!alreadyPlayed)
        gameOverSound.Play();
        alreadyPlayed = true;
    }
}
