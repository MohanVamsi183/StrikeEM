using UnityEngine;

public class VerticalMovement : MonoBehaviour
{
    public float moveDistance = 2f;  // The distance the object will move up and down from its starting position
    public float moveSpeed = 1f;     // The speed of the up and down movement

    private Vector3 startPos;
    private bool movingUp = true;

    void Start()
    {
        // Store the starting position of the object
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the target position
        Vector3 targetPos = movingUp ? startPos + Vector3.up * moveDistance : startPos - Vector3.up * moveDistance;

        // Move the object towards the target position at the defined speed
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // Reverse the direction when the object reaches the target position
        if (transform.position == targetPos)
        {
            movingUp = !movingUp;
        }
    }
}
