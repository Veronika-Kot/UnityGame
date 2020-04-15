using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUpdateScript : MonoBehaviour
{
    [Header("Scoreboard")]
    public Text scoreLabel;
    public Text livesLabel;

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
    public bool isEndGame() {
        if(lives <= 0) {
            SceneManager.LoadScene("EndScene");
            return true;
        } 
        return false;
    }
}
