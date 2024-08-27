using UnityEngine;
using System.Collections;

public class PulpitManager : MonoBehaviour
{
    public GameObject pulpitPrefab;
    private GameObject[] pulpits = new GameObject[2]; // Array to track the last two pulpits
    public float deletionDelay = 10.0f; // Time delay before the first pulpit is deleted

    private void Start()
    {
        StartCoroutine(SpawnPulpits());
    }

    IEnumerator SpawnPulpits()
    {
        // Spawn the first pulpit at a random position
        Vector3 initialPosition = new Vector3(0, 0, 0);
        pulpits[0] = Instantiate(pulpitPrefab, initialPosition, Quaternion.identity);

        while (true)
        {
            // Calculate a new spawn position in one of the cardinal directions
            Vector3 spawnPosition = GetNewPulpitPosition();

            // Spawn a new pulpit
            GameObject newPulpit = Instantiate(pulpitPrefab, spawnPosition, Quaternion.identity);

            // Move the current pulpit to the first position in the array
            pulpits[1] = pulpits[0];

            // Set the new pulpit as the current one
            pulpits[0] = newPulpit;

            // Start coroutine to delete the oldest pulpit after a delay
            StartCoroutine(DeleteOldestPulpitAfterDelay());

            // Wait for the specified time before spawning the next pulpit
            yield return new WaitForSeconds(GameManager.Instance.pulpitSpawnTime);
        }
    }

    IEnumerator DeleteOldestPulpitAfterDelay()
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(deletionDelay);

        // Destroy the oldest pulpit if it exists
        if (pulpits[1] != null)
        {
            Destroy(pulpits[1]);
        }
    }

    Vector3 GetNewPulpitPosition()
    {
        // Define the possible directions (North, South, East, West)
        Vector3[] directions = new Vector3[]
        {
            new Vector3(0, 0, 1),   // North
            new Vector3(0, 0, -1),  // South
            new Vector3(1, 0, 0),   // East
            new Vector3(-1, 0, 0)   // West
        };

        // Choose a random direction
        Vector3 randomDirection = directions[Random.Range(0, directions.Length)];

        // Calculate the new position based on the current pulpit's position and the chosen direction
        Vector3 newPosition = pulpits[0].transform.position + randomDirection * 10.0f; // Adjust the multiplier to control distance

        return newPosition;
    }
}
