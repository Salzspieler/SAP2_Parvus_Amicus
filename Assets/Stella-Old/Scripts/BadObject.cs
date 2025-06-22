using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadObject : MonoBehaviour
{
    
    private Player player;
    private int damage = 1;
   


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") == true)
        {
            player.KBCounter = player.KBTotalTime;
            if (other.transform.position.x <= transform.position.x)
            {
                player.KnockFromRight = true;
            }

            if (other.transform.position.x >= transform.position.x)
            {
                player.KnockFromRight = false;
            }
            player.TakeDamage(damage);
        }
    }

}
