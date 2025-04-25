using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadObject : MonoBehaviour
{
    private GameObject player;
    private Player _player;
    public Healthbar healthbar;
    public bool hit;

    private void Awake()
    {
        player = GameObject.Find("Player");
        
    }

    public void TakeDamage(int damage)
    {
        _player.currentHealth -= damage;
        healthbar.SetHealth(_player.currentHealth);
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        //check anderes Objekt ob es Ground ist
        if (other.gameObject.CompareTag("BadObject"))
        {
            hit = true;
            //animator.SetBool("isGrounded", true);
        }
        
    }


}
