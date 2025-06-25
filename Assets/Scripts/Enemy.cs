using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth;
    private int currentHealth;
    //SerializeField macht das "privat" Variablen angzeigt werden, bei anderen Scripten oder Unity
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private int currentWaypointIndex = 0;
    [SerializeField] private AudioClip ApprocheSound;
    [SerializeField] private AudioClip DieSound;
    public float speed = 3f;
    private GameObject player;
    public int attackDamage;
    private float distance;
    float volume = 1f;


    private void Start()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");
        currentHealth = maxHealth;
        player = GameObject.Find("Player");
        //enemyMovement = gameObject.GetComponent<EnemyMovement>();
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if (distance < 4)
        {
            //Debug.Log("Spieler gefunden");
            MoveToPlayer();
            SoundManager.instance.PlaySound(ApprocheSound, volume = 0.08f);
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
            SoundManager.instance.PlaySound(DieSound, volume = 0.08f);
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
