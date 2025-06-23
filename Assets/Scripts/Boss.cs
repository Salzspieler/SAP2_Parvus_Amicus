using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    public float speed = 3f;
    private GameObject player;
    public int attackDamage;
    public float fastspeed;
    public bool playerDetected = false;
    [SerializeField]private GameObject goal;

    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.Find("Player");
        if (goal == null)
        {
            return;
        }
    }


    private void Update()
    {
        if (playerDetected)
        {
            MoveToPlayer();
        }
    }
    

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    

    void Die()
    {
        //Debug.Log("Gegner ist Tot");
        goal.SetActive(true);
        Destroy(transform.parent.gameObject);
    }



    public void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, fastspeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
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
            player.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }
}
