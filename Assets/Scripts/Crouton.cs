using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouton : MonoBehaviour
{

    private CollectableLogic logic;

    private void Start()
    {
        logic = GameObject.Find("CollectableLogic").GetComponent<CollectableLogic>();
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
