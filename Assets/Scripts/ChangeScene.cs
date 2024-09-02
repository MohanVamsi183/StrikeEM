using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Method to change to a specific scene by name
    public void MainGameScene()
    {
        SceneManager.LoadScene("MainGame2");
    }

    public void MainMenuScene()
    {
    PlayerPrefs.DeleteAll();
    SceneManager.LoadScene("Menu");
    }

}