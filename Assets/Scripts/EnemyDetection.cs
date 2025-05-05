using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public Enemy enemy;
    public GameObject player;
    public bool isPlayerDetected = false;

    private void Update()
    {
        if(isPlayerDetected == true)
        {
            enemy.MoveToPlayer();
        }
        else
        {
            enemy.WayPointMove();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") == true)
        {
            Debug.Log("Spieler gefunden");
            isPlayerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") == false)
        {
            Debug.Log("OnTriggerExit2D");
            Debug.Log("Spieler verloren");
            isPlayerDetected = false;
        }
    }

}
