using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadObject : MonoBehaviour
{
    
    private Player player;
   


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") == true)
        {
            player.TakeDamage(1);
        }
    }

}
