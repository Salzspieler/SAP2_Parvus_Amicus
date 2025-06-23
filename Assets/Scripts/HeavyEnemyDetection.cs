using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemyDetection : MonoBehaviour
{
    [SerializeField]private GameObject bigEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Spieler Gefunden");
            bigEnemy.GetComponent<Boss>().playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Spieler verloren");
            bigEnemy.GetComponent<Boss>().playerDetected = false;
        }
    }
}
