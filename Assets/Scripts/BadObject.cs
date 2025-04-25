using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadObject : MonoBehaviour
{
    private GameObject player;
    public int damage = 1;
    

    private void Awake()
    {
        player = GameObject.Find("Player");
        
    }





    private void OnTriggerEnter2D(Collider2D other)
    {
        player.GetComponent<Player>().SpikeDamage(damage);
    }
    


}
