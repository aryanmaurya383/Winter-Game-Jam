using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMovement : MonoBehaviour
{

    public GameObject Ground1;
    public GameObject Ground2;
    public GameObject Ground3;
    public GameObject Ground4;
    public GameObject Ground5;
    private float spawnMoreTime;
    
    private void Start()
    {
        spawnMoreTime = 0;
    }
    private void Update()
    {
        spawnMoreTime += Time.deltaTime;
    }
    public void GroundSpawn()
    {
        int randomNum = Random.Range(1, 6);
        //int randomNum = 5;

        if (randomNum == 1)
        {
            Instantiate(Ground1, new Vector3(transform.position.x + 17.055f, -4.94f, 0f), Quaternion.identity);

        }
        else if (randomNum == 2)
        {
            Instantiate(Ground2, new Vector3(transform.position.x + 27.504f, -4.45f, 0f), Quaternion.identity);

        }
        else if (randomNum == 3)
        {
            Instantiate(Ground3, new Vector3(transform.position.x + 16.381f, -3.02f, 0f), Quaternion.identity);

        }
        else if (randomNum == 4)
        {
            Instantiate(Ground4, new Vector3(transform.position.x + 19.194f, -5.22f, 0f), Quaternion.identity);

        }
        else if (randomNum == 5)
        {
            Instantiate(Ground5, new Vector3(transform.position.x + 19.04f, -2.565f, 0f), Quaternion.identity);

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (this.CompareTag("GroundBoundaryEnter")&&collision.CompareTag("Ground")&&spawnMoreTime>4 )
        {
            GroundSpawn();
            spawnMoreTime = 0;
        }
        if (this.CompareTag("GroundBoundaryExit") && collision.CompareTag("Ground") )
        {
            Destroy(collision.gameObject);
            
        }
    }
}
