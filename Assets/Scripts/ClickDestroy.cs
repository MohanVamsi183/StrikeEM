using UnityEngine;

public class ClickDestroy : MonoBehaviour
{
    public AudioClip destroySound;           // Sound to play when the object is destroyed
    public GameObject explosionEffect;       // Explosion effect prefab to instantiate on destroy

    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component if it doesn't exist
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = destroySound;
    }

    void OnMouseDown()
    {
        // Play the destroy sound
        if (audioSource && destroySound)
        {
            audioSource.Play();
        }

        // Instantiate the explosion effect at the object's position and rotation
        GameObject explosionInstance = null;
        if (explosionEffect)
        {
            explosionInstance = Instantiate(explosionEffect, transform.position, transform.rotation);
        }

        // Destroy the explosion effect after 2 seconds
        if (explosionInstance)
        {
            Destroy(explosionInstance, 0.5f);
        }

        // Destroy the game object after 2 seconds, regardless of the sound's length
        Destroy(gameObject, 0.5f);
    }
}
