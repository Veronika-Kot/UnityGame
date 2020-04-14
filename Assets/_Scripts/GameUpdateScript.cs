using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUpdateScript : MonoBehaviour
{
    public Text scoreLabel;
    private int score;

    public static int Score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }      

    public void addScore() {
        score ++;
        scoreLabel.text = "Score: " + score.ToString();
    }
}
