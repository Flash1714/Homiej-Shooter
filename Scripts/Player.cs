using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 100;
    public int score = 0;
    public Text healthDisplay;
    public Text scoreDisplay;
    public Text highScoreDisplay;

    // Start is called before the first frame update
    void Start()
    {
        highScoreDisplay.text = "HighScore : " + PlayerPrefs.GetInt("HighScore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(health<= 0)
        {
            Destroy(gameObject);
            healthDisplay.text = "0";
            if (score > PlayerPrefs.GetInt("HighScore",0))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
        else
        {
            healthDisplay.text = "HP : " + health.ToString();
            scoreDisplay.text = "Kills : " + score.ToString();
        }


    }
}
