using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Logic logic;


    private void Awake()
    {
        //2. Script Referenzieren (GO in Scene suchen und finden)
        logic = GameObject.Find("Logic").GetComponent<Logic>();

    }
    void OnCollosionEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Collect();
        }
        
    }

    void Collect()
    {
        //optisch ausschalten
        GetComponent<Renderer>().enabled = false;
        this.gameObject.SetActive(false);
        
        //print("Collect");
    }

    
}
