
using UnityEngine; // Import UnityEngine namespace for Debug and other Unity classes
using TMPro; // Import the TextMeshPro namespace
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class GameManager : MonoBehaviour
{
    public TMP_Text timerText;        // Reference to the TextMeshPro Text element for the timer
    public TMP_Text scoreText;        // Reference to the TextMeshPro Text element for the score
    public float gameDuration = 60f;  // Duration of the game in seconds
    private float timeRemaining;
    private int score;

    void Awake()
    {
        // Ensure only one GameManager exists and persists across scenes
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        // Check if references are assigned
        if (timerText == null || scoreText == null)
        {
            UnityEngine.Debug.LogError("TimerText or ScoreText is not assigned.");
            return;
        }

        ResetGame();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();

            if (timeRemaining <= 0)
            {
                timeRemaining = 0;  // Ensure timeRemaining doesn't go negative
                UpdateTimerText();
                EndGame();
            }
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.Clamp(timeRemaining, 0f, gameDuration).ToString("F2") + "s";
        }
        else
        {
            UnityEngine.Debug.LogError("TimerText is not assigned.");
        }
    }

    public void UpdateScore(int points)
    {
        score += points;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            UnityEngine.Debug.LogError("ScoreText is not assigned. Please assign it in the Inspector.");
        }
    }

    void EndGame()
    {
        // Save the final score in PlayerPrefs
        PlayerPrefs.SetInt("FinalScore", score);

        // Load the end game scene
        SceneManager.LoadScene("EndGameScene"); // Ensure this scene exists
    }

    void ResetGame()
    {
        // Reset the game state
        timeRemaining = gameDuration;
        score = 0; // Reset score to 0
        UpdateTimerText();
        UpdateScoreText();
    }

    public void RestartGame()
    {
        // Remove the persistent GameManager instance
        Destroy(gameObject);

        // Reload the main menu or initial scene
        SceneManager.LoadScene("Menu"); 
    }
}
