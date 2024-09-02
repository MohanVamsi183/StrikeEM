using UnityEngine;

public class LevitatingEffect : MonoBehaviour
{
    public float amplitude = 0.5f;  // The height of the levitation
    public float frequency = 1f;    // The speed of the levitation

    private Vector3 startPos;

    void Start()
    {
        // Record the starting position of the object
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position using a sine wave for smooth movement
        float newY = startPos.y + Mathf.Sin(Time.time * frequency) * amplitude;

        // Apply the new position to the object
        transform.position = new Vector3(startPos.x, newY, startPos.z);
    }
}
