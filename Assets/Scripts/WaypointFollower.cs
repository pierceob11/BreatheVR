using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public Transform[] waypoints; // An array of waypoints for the object to follow
    public float movementSpeed = 5f; // The movement speed of the object
    public float turningSpeed = 5f; // The turning speed of the object

    private int currentWaypointIndex = 0; // Index of the current waypoint

    void Update()
    {
        // Calculate the direction to the current waypoint
        Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
        direction.y = 0f; // Set the y-component of the direction to zero

        // Smoothly rotate the object to face the waypoint
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

        // Normalize the direction and multiply it by the movement speed
        Vector3 movement = direction.normalized * movementSpeed * Time.deltaTime;

        // Move the object towards the waypoint (excluding the y-axis)
        transform.Translate(new Vector3(movement.x, 0f, movement.z));

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
