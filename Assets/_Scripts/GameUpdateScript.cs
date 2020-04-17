/**
* Author: Veronika Kotckovich
* Student ID: 301067511
**/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Class to keep Game globals and helper functions
public class GameUpdateScript : MonoBehaviour
{
    [Header("Scoreboard")]
    public Text scoreLabel;
    public Text livesLabel;

    // Private variables
    private int score;
    private int lives;

    public static int Score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 5;

        scoreLabel.text = "Score: " + score.ToString();
    }   

    public void addScore() {
        score ++;
        scoreLabel.text = "Score: " + score.ToString();
    }

    public void addLife() {
        lives ++;
        livesLabel.text = "Lives: " + lives.ToString();
    }

    public void removeLife() {
        lives --;
        livesLabel.text = "Lives: " + lives.ToString();
    }

    public void endGame(){
        SceneManager.LoadScene("EndScene");
    }
    public bool isEndGame() {
        if(lives < 1) {
            endGame();
            return true;
        } 
        return false;
    }
}
