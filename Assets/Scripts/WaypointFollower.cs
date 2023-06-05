using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public Transform[] waypoints; // An array of waypoints for the object to follow
    public float movementSpeed = 5f; // The movement speed of the object
    public float turningSpeed = 5f; // The turning speed of the object
    public float minDistanceToWaypoint = 1f; // The minimum distance to maintain from the waypoint
    public float waitTime = 1f; // The wait time in seconds before moving to the next waypoint

    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool isWaiting = false; // Flag indicating if the object is waiting

    void Start()
    {
        // Print the initial waypoint the object is moving towards
        Debug.Log("Moving towards waypoint: " + currentWaypointIndex);
    }

    void Update()
    {
        // Calculate the direction to the current waypoint
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        direction.y = 0f; // Set the y-component of the direction to zero

        // Check if the object is within the minimum distance to the waypoint
        if (direction.magnitude <= minDistanceToWaypoint)
        {
            if (!isWaiting)
            {
                // Start waiting
                isWaiting = true;
                StartCoroutine(WaitBeforeNextWaypoint());
            }
        }
        else
        {
            // Smoothly rotate the object to face the waypoint
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

            // Normalize the direction and multiply it by the movement speed
            Vector3 movement = direction.normalized * movementSpeed * Time.deltaTime;

            // Move the object towards the waypoint (excluding the y-axis)
            transform.Translate(new Vector3(movement.x, 0f, movement.z));
        }
    }

    System.Collections.IEnumerator WaitBeforeNextWaypoint()
    {
        // Print the new waypoint the object is moving towards
        Debug.Log("Reached waypoint: " + currentWaypointIndex);

        // Wait for the specified wait time
        yield return new WaitForSeconds(waitTime);

        // Increment the waypoint index
        currentWaypointIndex++;

        // Check if the current waypoint index exceeds the array length
        if (currentWaypointIndex >= waypoints.Length)
        {
            // Reset the waypoint index to loop back to the first waypoint
            currentWaypointIndex = 0;
        }

        // Print the new waypoint the object is moving towards
        Debug.Log("Moving towards waypoint: " + currentWaypointIndex);

        // Stop waiting
        isWaiting = false;
    }
}
