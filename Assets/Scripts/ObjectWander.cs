using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWander : MonoBehaviour
{
    public float speed = 3f;
    public float rotationSpeed = 2f;
    public float wanderRadius = 5f;
    public float avoidanceDistance = 3f;
    public GameObject[] avoidObjects;

    private Vector3 targetPosition;

    private void Start()
    {
        // Locking the object's y-axis
        transform.eulerAngles = new Vector3(0f, transform.eulerAngles.y, 0f);
        targetPosition = GetRandomPosition();
    }

    private void Update()
    {
        // Calculate direction to the target position
        Vector3 direction = targetPosition - transform.position;

        // Check for nearby obstacles and avoid them
        foreach (GameObject avoidObject in avoidObjects)
        {
            if (Vector3.Distance(transform.position, avoidObject.transform.position) < avoidanceDistance)
            {
                direction += (transform.position - avoidObject.transform.position).normalized;
            }
        }

        // Rotate towards the target position
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move towards the target position
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Check if the object reached the target position
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            targetPosition = GetRandomPosition();
        }
    }

    private Vector3 GetRandomPosition()
    {
        // Generate a random position within the wander radius
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        randomDirection.y = transform.position.y; // Locking the y-axis
        return randomDirection;
    }
}
