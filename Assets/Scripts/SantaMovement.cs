using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaMovement : MonoBehaviour
{
    public float santaSpeed;
    public AudioSource spaceShipMusic;
    public Rigidbody2D santaRB;
    public SpriteRenderer spriteRenderer;
    public bool musicOn;
    // Start is called before the first frame update
    void Start()
    {
        santaSpeed = 3f;
        spaceShipMusic.Play();
        musicOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.isPaused)
        {
            spaceShipMusic.Pause();
            musicOn = false;
        }
        else if(!PlayerMovement.isPaused && !musicOn)
        {
            spaceShipMusic.Play();
            musicOn = true;
        }
        if (PlayerSearching.isDead)
        {
            spaceShipMusic.Stop();
        }
        santaRB.velocity = new Vector2(santaSpeed, santaRB.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("santaBoundary"))
        {
            if (santaSpeed == 3f)
            {
                santaSpeed = -3f;
                spriteRenderer.flipX = true;
            }
            else
            {
                santaSpeed = 3f;
                spriteRenderer.flipX = false;
            }
        }
    }


}
