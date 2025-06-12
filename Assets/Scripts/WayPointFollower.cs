using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private int currentWaypointIndex = 0;
    [SerializeField] private float speed = 3f;

    private void Update()
    {
        //next Waypoint logic
        if (Vector2.Distance(wayPoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        //moveLogic
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.parent = null;
        }

    }
}
