using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyEnemy : MonoBehaviour
{

    public int maxHealth;
    private int currentHealth;
    [SerializeField] GameObject[] wayPoints;
    [SerializeField] private int currentWaypointIndex = 0;
    public float speed = 3f;
    private GameObject player;
    public int attackDamage;
    public float fastspeed;
    public bool playerDetected = false;

    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.Find("Player");
    }


    private void Update()
    {
        if (playerDetected)
        {
            MoveToPlayer();
        }
        else
        {
            WayPointMove();
        }
    }
    public void WayPointMove()
    {
        //next Waypoint logic
        if (Vector2.Distance(wayPoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= wayPoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        //moveLogic
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
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
