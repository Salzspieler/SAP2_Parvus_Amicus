using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class FlyingEnemy : MonoBehaviour
{
    public int maxHealth;
    private int currentHealth;
    //SerializeField macht das "privat" Variablen angzeigt werden, bei anderen Scripten oder Unity
    [SerializeField] private Transform startPoint;
    public float speed = 4f;
    private GameObject player;
    public int attackDamage;
    public bool playerDetected = false;
    [SerializeField]private GameObject projectile;
    [SerializeField]private Transform launchPoint;
    [SerializeField]private AudioClip ApprocheSound;
    float volume = 1f;

    private float timer;

    private void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.Find("Player");
        //projectile = GameObject.Find("EnemyProjectile");
    }

    private void Update()
    {
        if (player == null) {
            return;
        }

        timer += Time.deltaTime;
        if (playerDetected)
        {
            if (timer <= 2)
            {
                AttackPlayer();
                SoundManager.instance.PlaySound(ApprocheSound, volume = 0.08f);
            }
            //schießen und mit Zeit, zwischen den Schüssen
            else if(timer > 2)
            {
                timer = 0;
                ShootPlayer();
                SoundManager.instance.PlaySound(ApprocheSound, volume = 0.08f);
            }


        }
        else
        {
            MoveToStartPoint();
        }
    }

    public void AttackPlayer()
    {
        //Debug.Log("Attack Player");
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void ShootPlayer()
    {
        //Debug.Log("Shoot Player");
        Instantiate(projectile, launchPoint.transform.position, Quaternion.identity);
        
    }
    public void MoveToStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
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
            player.GetComponent<Player>().TakeDamage(attackDamage);
        }
    }


}
