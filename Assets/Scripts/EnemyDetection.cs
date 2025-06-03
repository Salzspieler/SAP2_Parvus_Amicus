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
        enemy = GameObject.Find("Enemy").GetComponent<Enemy>();
        //enemyMovement = GameObject.Find("Normal Enemy").GetComponent<EnemyMovement>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (isPlayerDetected == true)
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
        if(other.CompareTag("Player"))
        {
            Debug.Log("Spieler gefunden");
            isPlayerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") == false)
        {
            Debug.Log("Spieler verloren");
            isPlayerDetected = false;
        }
    }

}
