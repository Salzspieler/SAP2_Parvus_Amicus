using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouton : MonoBehaviour
{

    private Logic logic;

    private void Start()
    {
        logic = GameObject.Find("CollectableLogic").GetComponent<Logic>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CollectCrouton();
        }
    }


    void CollectCrouton()
    {
        logic.CountCroutons();
        Destroy(gameObject);
    }
}
