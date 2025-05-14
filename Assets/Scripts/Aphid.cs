using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Aphid : MonoBehaviour
{
    public float speed;
    private Logic logic;


    private void Start()
    {
        logic = GameObject.Find("Logic").GetComponent<Logic>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }


    void Throw()
    {

    }

    void Collect()
    {
        // optisch ausschalten
        GetComponent<Renderer>().enabled = false;
        gameObject.SetActive(false);
        

        //print("Collect");
    }

}
