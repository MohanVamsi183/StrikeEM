
using UnityEngine;
using TMPro; // Import the TextMeshPro namespace
using UnityEngine.SceneManagement;
public class EndGameManager : MonoBehaviour
{
    public TMP_Text finalScoreText; 

    void Start()
    {
        // Retrieve the final score from PlayerPrefs
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);

        // Display the final score
        if (finalScoreText != null)
        {
            finalScoreText.text = "Final Score: " + finalScore;
            PlayerPrefs.DeleteAll();
        }
        else
        {
            Debug.LogError("FinalScoreText is not assigned.");
        }
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

