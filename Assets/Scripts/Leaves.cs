using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Leaves : MonoBehaviour
{
    private Logic logic;
    


    private void Awake()
    {
        logic = GameObject.Find("CollectableLogic").GetComponent<Logic>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectLeaves();
        }
        
    }

    void CollectLeaves()
    {
        if(logic.leavesCount < 4)
        {
            logic.CountLeaves();
            Destroy(gameObject);
        }

        //print("Collect");
    }

    
}
