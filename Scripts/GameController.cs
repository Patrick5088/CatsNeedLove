using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public GUIText scoreText;
    public GUIText gameOverText;
    public GUIText restartText;
    public GUIText winText;
 
    private bool gameOver;
    private bool restart;
    private int score;

    // Use this for initialization
    void Start () {

        gameOver = false;
        restart = false;
        gameOverText.text = "";
        restartText.text = "";
        winText.text = "";
        score = 0;
        UpdateScore();
        
            
    }
    private void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Scenes/Main");
                

            }
        }
        if (gameOver)
        {
            restartText.text = "Press 'R' to Restart";
            restart = true;
            
        }
    }
   
    public void Win()
    {
        gameOverText.text = "Hurray";
        gameOver = true;
        
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over!";
        gameOver = true;
    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
   
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
