using System;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 5f;            // Speed of the object's movement
    public float moveAreaRadius = 10f;      // Radius of the movement area

    private Vector3 initialPosition;        // The initial position of the object
    private Vector3 randomDirection;        // The current random direction of movement

    void Start()
    {
        // Store the initial position of the object
        initialPosition = transform.position;

        // Set an initial random direction
        SetRandomDirection();
    }

    void Update()
    {
        // Move the object in the current random direction
        transform.Translate(randomDirection * moveSpeed * Time.deltaTime);

        // Check if the object is moving out of the defined area
        if (Vector3.Distance(initialPosition, transform.position) > moveAreaRadius)
        {
            // If out of bounds, set a new random direction to move back towards the center
            SetRandomDirection();
        }
    }

    void SetRandomDirection()
    {
        // Generate a random direction vector for X and Y only
        float randomX = UnityEngine.Random.Range(-1f, 1f);
        float randomY = UnityEngine.Random.Range(-1f, 1f);

        // Set the direction, ensuring no movement along the Z axis
        randomDirection = new Vector3(randomX, randomY, 0f).normalized;

        // Ensure the object moves towards the center if it's moving out of bounds
        Vector3 directionToCenter = new Vector3(
            initialPosition.x - transform.position.x,
            initialPosition.y - transform.position.y,
            0f
        ).normalized;

        // Blend the random direction with the direction to the center
        randomDirection = Vector3.Lerp(randomDirection, directionToCenter, 0.5f).normalized;
    }
}
