using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
   public int playerScore;
   public Text Scoretext;
   public Text HighscoreText; // Highscore-Textfeld für den UI-Anzeige
   public GameObject gameOverScreen;
   public AudioSource scoreSound;
   private int highScore;

    void Start()
    {
        // Lade den gespeicherten Highscore bei Spielstart
        highScore = PlayerPrefs.GetInt("Highscore", 0);
        HighscoreText.text = "Highscore: " + highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        Scoretext.text = playerScore.ToString();
        scoreSound.Play();

        // Überprüfen, ob ein neuer Highscore erreicht wurde
        if (playerScore > highScore)
        {
            highScore = playerScore;
            HighscoreText.text = "Highscore: " + highScore.ToString();
            PlayerPrefs.SetInt("Highscore", highScore); // Speichere den neuen Highscore
            PlayerPrefs.Save(); // Speichert die Änderungen sofort auf die Festplatte
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
