using System.Diagnostics;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public AudioClip destroySound;           // Sound to play when the object is destroyed
    public GameObject explosionEffect;       // Explosion effect prefab to instantiate on destroy
    public float respawnTime = 5f;           // Time in seconds before the object is reactivated

    public GameObject additionalObject;      // The other object to be deactivated along with this one

    private AudioSource audioSource;

    public int points = 10;


    void Start()
    {
        // Add an AudioSource component if it doesn't exist
        if (!TryGetComponent(out audioSource))
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Ensure the AudioSource is configured properly
        audioSource.clip = destroySound;
        audioSource.playOnAwake = false;
    }

    void OnMouseDown()
    {
        // Play the destroy sound
        if (audioSource && destroySound)
        {
            audioSource.Play();
            
        }

        // Instantiate the explosion effect at the object's position and rotation
        if (explosionEffect)
        {
            GameObject explosionInstance = Instantiate(explosionEffect, transform.position, transform.rotation);
            Destroy(explosionInstance, 1f); // Destroy the explosion effect after 0.5 seconds
        }

        // Delay the deactivation to ensure the audio plays
        Invoke("DeactivateObjects", 0.5f);
    }


    void DeactivateObjects()
    {
        // Deactivate the object and the additional object if assigned
        gameObject.SetActive(false);
        if (additionalObject != null)
        {
            additionalObject.SetActive(false);
        }

        // Start the reactivation process
        Invoke("ReactivateObjects", respawnTime);

        // Ensure GameManager exists and is properly initialized
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            // Log the current state of scoreText
            if (gameManager.scoreText != null)
            {
                UnityEngine.Debug.Log("GameManager's ScoreText is assigned and updating score.");
                gameManager.UpdateScore(points);
            }
            else
            {
                UnityEngine.Debug.LogError("GameManager's ScoreText is not assigned.");
                UnityEngine.Debug.Log("GameManager details - ScoreText: " + gameManager.scoreText);
            }
        }
        else
        {
            UnityEngine.Debug.LogError("GameManager not found. Score update failed.");
        }
    }




    void ReactivateObjects()
    {
        // Reactivate the objects
        gameObject.SetActive(true);
        if (additionalObject != null)
        {
            additionalObject.SetActive(true);
        }
    }
}


