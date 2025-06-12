using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemyDetection : MonoBehaviour
{
    [SerializeField]private GameObject heavyEnemy;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Spieler Gefunden");
            heavyEnemy.GetComponent<HeavyEnemy>().playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Spieler verloren");
            heavyEnemy.GetComponent<HeavyEnemy>().playerDetected = false;
        }
    }
}
