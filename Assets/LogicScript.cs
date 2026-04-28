using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject startScreen;
    public GameObject gameOverScreen;
    public AudioSource dingSoundEffect;
    private bool gameStarted = false;

    // for GameOverScript
    public Text finalScoreText;    // shows score on Game Over screen
    public TextMeshProUGUI highScoreText;     // shows best score on Game Over screen
    private void Start()
    {
        Time.timeScale = 0; // pause game at start
    }

    public void startGame()
    {
        Time.timeScale = 1; // start game
        startScreen.SetActive(false);
        gameStarted = true;
    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        dingSoundEffect.Play();
    }

    public void restartGame()
    {
        // for "Play Again" Button
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        // trigger when player crach onto pipes
        gameOverScreen.SetActive(true);

        finalScoreText.text = "Score: " + playerScore.ToString();

        // Save & show high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (playerScore > highScore)
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        highScoreText.text = "Best: " + highScore.ToString();
    }
}
