using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{

    public int maxHealth = 10;
    int currentHealth;
    public float speed = 3f;
    public GameObject player;
    public int attackDamage = 1;
    private EnemyDetection enemyDetected;
    public Transform startingPoint;

    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.Find("Player");
        enemyDetected = GameObject.Find("FlyingDetectionZone").GetComponent<EnemyDetection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDetected.isPlayerDetected == true)
        {
            //Debug.Log("Spieler gefunden");
            MoveToPlayer();
        }
        else
        {
            ReturnStartPoint();
        }
    }

    void ReturnStartPoint() {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
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
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            //player.GetComponent<Player>().KBCounter = 
            player.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }

    public void MoveToPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
