using UnityEngine;
using System.Collections;

public class RespawnManager : MonoBehaviour
{
    public static RespawnManager Instance;

    void Awake()
    {
        // Ensure there is only one instance of RespawnManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Respawn(GameObject[] objectsToRespawn, Vector3[] positions, Quaternion[] rotations, float respawnTime)
    {
        StartCoroutine(RespawnCoroutine(objectsToRespawn, positions, rotations, respawnTime));
    }

    private IEnumerator RespawnCoroutine(GameObject[] objectsToRespawn, Vector3[] positions, Quaternion[] rotations, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Iterate through each object and reset its position, rotation, and activation status
        for (int i = 0; i < objectsToRespawn.Length; i++)
        {
            if (objectsToRespawn[i] != null)
            {
                objectsToRespawn[i].transform.position = positions[i];
                objectsToRespawn[i].transform.rotation = rotations[i];
                objectsToRespawn[i].SetActive(true);
            }
        }
    }
}
