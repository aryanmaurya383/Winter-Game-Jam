using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI score;
    public static float scoreValue;
    public static float finalScoreValue;
    public static float starsCollected;
    public float initialPosition;
    public float distance;
    public float maxDistance;
    public Rigidbody2D player;
    void Start()
    {
        starsCollected = 0;
        initialPosition = player.position.x;
        distance = 0;
        maxDistance = -100;
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        distance = player.position.x - initialPosition;
        maxDistance = Mathf.Max(distance, maxDistance);
        scoreValue = maxDistance + starsCollected;
        if (scoreValue > finalScoreValue)
        {
            finalScoreValue = scoreValue;
        }

        score.text = "Score: " + ((int)scoreValue).ToString();
    }
}
