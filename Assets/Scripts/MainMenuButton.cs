using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void OnClickBackToMenu()
    {
        // Find and destroy any existing GameManager instances
        GameManager[] gameManagers = FindObjectsOfType<GameManager>();
        foreach (GameManager gameManager in gameManagers)
        {
            Destroy(gameManager.gameObject);
        }

        
        PlayerPrefs.DeleteAll(); // Clears all PlayerPrefs data

        // Load the main menu scene
        SceneManager.LoadScene("Menu"); 
    }
}
