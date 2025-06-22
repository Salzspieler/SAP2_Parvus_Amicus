using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionWithCollider : MonoBehaviour
{
    [SerializeField]private GameObject flyingEnemy;

    private void Awake()
    {
        if(flyingEnemy == null)
        {
            return;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Spieler Gefunden");
            flyingEnemy.GetComponent<FlyingEnemy>().playerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Debug.Log("Spieler verloren");
            flyingEnemy.GetComponent<FlyingEnemy>().playerDetected = false;
        }
    }

}
