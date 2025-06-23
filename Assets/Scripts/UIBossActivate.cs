using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBossActivate : MonoBehaviour
{
    [SerializeField] private GameObject UIBoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIBoss.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIBoss.SetActive(false);
        }
    }
}
