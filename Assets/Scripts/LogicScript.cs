using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
   public int playerScore;
   public Text Scoretext;
   public Text HighscoreText; 
   public GameObject gameOverScreen;
   public AudioSource scoreSound;
   private int highScore;

    void Start()
    {
        
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        HighscoreText.text = "Highscore: " + highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        Scoretext.text = playerScore.ToString();
        scoreSound.Play();

        
        if (playerScore > highScore)
        {
            highScore = playerScore;
            HighscoreText.text = "Highscore: " + highScore.ToString();
            PlayerPrefs.SetInt("Highscore", highScore); 
            PlayerPrefs.Save(); 
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
