using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;

    private enum direction
    {
        Left,
        Right
    }

    private int currentWaypointIndex = 0;
    [SerializeField] private Transform gfxObject;
    [SerializeField] private direction defDirection;
    [SerializeField] private bool RandomWayPoints;

    private void Start()
    {

        if (RandomWayPoints)
            RandomizeArray(waypoints);

        if (waypoints.Length > 0)
        {
            transform.position = waypoints[currentWaypointIndex].position;
        }

    }

    private void Update()
    {
        if (waypoints.Length == 0)
        {
            return;
        }
        
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        
        Vector3 moveDirection = targetPosition - transform.position;

        if (defDirection == direction.Left)
        {
            if (moveDirection.x < 0)
            {
                gfxObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (moveDirection.x > 0)
            {
                gfxObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        else
        {
            if (moveDirection.x < 0)
            {
                gfxObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (moveDirection.x > 0)
            {
                gfxObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
    
    private void RandomizeArray<T>(T[] array)
    {
        int n = array.Length;
        System.Random random = new System.Random();

        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }

}
