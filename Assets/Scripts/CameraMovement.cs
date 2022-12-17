using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed=0.125f;
    public AudioSource backgroundMusic;
    public bool musicOn;
    public Vector3 offset;
    // Update is called once per frame
    private void Start()
    {
        musicOn = true;
        backgroundMusic.Play();

    }
    
    private void FixedUpdate()
    {
        if (PlayerMovement.isPaused)
        {
            backgroundMusic.Pause();
            musicOn = false;
        }
        else if (!PlayerMovement.isPaused && !musicOn)
        {
            backgroundMusic.Play();
            musicOn = true;
        }
        Vector3 desiredPosition= new Vector3(player.position.x + offset.x, transform.position.y+offset.y,transform.position.z+offset.z);
        
        
        Vector3 smoothedPosition=Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }
}
