using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public Transform[] waypoints; // An array of waypoints for the object to follow
    public float movementSpeed = 5f; // The movement speed of the object

    private int currentWaypointIndex = 0; // Index of the current waypoint

    void Update()
    {
        // Calculate the direction to the current waypoint
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;

        // Normalize the direction and multiply it by the movement speed
        Vector3 movement = direction.normalized * movementSpeed * Time.deltaTime;

        // Move the object towards the waypoint
        transform.Translate(movement);

        // Check if the object has reached the current waypoint
        if (direction.magnitude <= movement.magnitude)
        {
            // Increment the waypoint index
            currentWaypointIndex++;

            // Check if the current waypoint index exceeds the array length
            if (currentWaypointIndex >= waypoints.Length)
            {
                // Reset the waypoint index to loop back to the first waypoint
                currentWaypointIndex = 0;
            }
        }
    }
}
