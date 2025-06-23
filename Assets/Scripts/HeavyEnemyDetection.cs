using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemyDetection : MonoBehaviour
{
    [SerializeField]private GameObject boss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Spieler Gefunden");
            boss.GetComponent<Boss>().playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Spieler verloren");
            boss.GetComponent<Boss>().playerDetected = false;
        }
    }
}
