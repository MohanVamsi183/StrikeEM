
using UnityEngine;

public class LevitatingAndMovingEffect : MonoBehaviour
{
    public float levitationAmplitude = 0.5f;  // The height of the levitation (how far it moves up and down)
    public float levitationFrequency = 1f;    // The speed of the levitation (how fast it moves up and down)

    public float xMoveSpeed = 1f;             // The speed at which the object moves along the X-axis
    public float xMovementRange = 2f;         // The range of movement along the X-axis

    public float yMoveSpeed = 1f;             // The speed at which the object moves along the Y-axis
    public float yMovementRange = 0.5f;       // The range of movement along the Y-axis (additional movement beyond levitation)

    private Vector3 startPos;

    void Start()
    {
        // Store the starting position of the object
        startPos = transform.position;
    }

    void Update()
    {
        // Calculate the new Y position combining levitation and additional Y movement
        float newY = startPos.y + Mathf.Sin(Time.time * levitationFrequency) * levitationAmplitude
                               + Mathf.Sin(Time.time * yMoveSpeed) * yMovementRange;

        // Calculate the new X position using a sine wave for smooth left-right movement
        float newX = startPos.x + Mathf.Sin(Time.time * xMoveSpeed) * xMovementRange;

        // Apply the new X and Y positions, keeping the Z position unchanged
        transform.position = new Vector3(newX, newY, startPos.z);
    }
}
