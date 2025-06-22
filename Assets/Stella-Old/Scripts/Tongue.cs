using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{

    private GameObject player;
    [SerializeField] private int damage;
    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Player>().KBCounter = player.GetComponent<Player>().KBTotalTime;
            if (collision.transform.position.x <= transform.position.x)
            {
                player.GetComponent<Player>().KnockFromRight = true;
            }

            if (collision.transform.position.x >= transform.position.x)
            {
                player.GetComponent<Player>().KnockFromRight = false;
            }
            player.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
