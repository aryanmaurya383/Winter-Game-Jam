using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static Vector2  player_velocity;
    public AudioSource runningSound;
    public AudioSource jumpingSound;
    float xspeed;
    public Rigidbody2D player;
    public SpriteRenderer spriteRenderer;
    public Sprite oldSprite;
    public Sprite newSprite;
    public static bool isGrounded;
    public Animator animator; 
    public static bool isPaused;
    public static bool isCamouflauge;

    [SerializeField] GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        isCamouflauge= false;
        isGrounded = true;
        player_velocity.x = 0;
        player_velocity.y = 0;
        xspeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMovement.isPaused = true;
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }   
        animator.SetFloat("Speed", Mathf.Abs(player_velocity.x));
        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }
        else
        {
            animator.SetBool("IsJumping", true);
        }

        if ((Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && !isPaused)
        {
            if (!isCamouflauge)
            {
            jumpingSound.Play();
            player.AddForce(new Vector2(0f, 400f));
            }
        }

        if ((Input.GetKeyDown("a") || Input.GetKeyDown("d") || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && !isPaused)
        {
            if (!isCamouflauge)
            {
                runningSound.Play();
            }
        }
        if ((Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)))
        {
            if (!isCamouflauge)
            {
                player_velocity.x = -xspeed;
                spriteRenderer.flipX = true;
            }

        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (!isCamouflauge)
            {
                player_velocity.x = 0;
                runningSound.Stop();
            }
        }

        if (Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (isCamouflauge)
            {
                isCamouflauge = false;
                spriteRenderer.sprite = oldSprite;
                animator.enabled = true;
                PlayerSearching.colourNotMatching = true;
            }
            else
            {
                isCamouflauge = true; 
                spriteRenderer.sprite = newSprite;
                animator.enabled = false;
                PlayerSearching.colourNotMatching = false;
            }
            
        }
        

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow))
        {
            if (!isCamouflauge)
            {
                player_velocity.x = xspeed;
                spriteRenderer.flipX = false;
            }
        }
        if (Input.GetKeyUp("d") || Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (!isCamouflauge)
            {
                player_velocity.x = 0;
                runningSound.Stop();
            }
        }

        player_velocity.y = player.velocity.y;
        player.velocity = player_velocity;
        if (Mathf.Abs(player.velocity.y) < 0.01)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    
    /***
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    ***/
}
