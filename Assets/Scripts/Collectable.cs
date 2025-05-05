using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private Logic logic;
    private AudioSource collectSound;

    private void Awake()
    {
        //2. Script Referenzieren (GO in Scene suchen und finden)
        logic = GameObject.Find("Logic").GetComponent<Logic>();
        collectSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Collect();
    }

    void Collect()
    {
        //optisch ausschalten
        GetComponent<Renderer>().enabled = false;  
        logic.itemsCollected++;
        logic.itemsCollectedText.text = "Items: " + logic.itemsCollected.ToString();
        collectSound.Play();
        //print("Collect");
        Destroy(gameObject, collectSound.clip.length);
    }

    
}
