using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 10;
    int currentHealth;
    //SerializeField macht das "privat" Variablen angzeigt werden, bei anderen Scripten oder Unity
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private int currentWaypointIndex = 0;
    public float speed = 3f;
    public GameObject player;
    private float distance;
    public int attackDamage;
    //public CircleCollider2D DetectionRadius;
    //public GameObject player;
    //public bool isPlayerDetected = false;

    private void Start()
    {
        currentHealth = maxHealth;
        

    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (distance < 6) 
        {
            //Debug.Log("Spieler gefunden");
            MoveToPlayer();
        }
        else
        {
            //Debug.Log("Spieler nicht gefunden und WayPointMove wird ausgeführt");
            WayPointMove();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Debug.Log("Gegner ist Tot");
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") == true)
        {
            //player.GetComponent<Player>().KBCounter = 
            player.GetComponent<Player>().TakeDamage(attackDamage);
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

    public void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }


    
}
