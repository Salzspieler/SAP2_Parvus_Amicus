using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 2f;
    private bool goingToB = true;

    void Update()
    {
        if (goingToB)
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed * Time.deltaTime);

        if (transform.position == pointB.position) goingToB = false;
        if (transform.position == pointA.position) goingToB = true;
    }
}


