using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public Enemy enemy;
    public GameObject player;
    public bool isPlayerDetected = false;

    private void Start()
    {
        //enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        player = GameObject.Find("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Spieler gefunden");
            enemy.MoveToPlayer();
            isPlayerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") == false)
        {
            Debug.Log("Spieler verloren");
            enemy.WayPointMove();
            isPlayerDetected = false;
        }
    }

}
