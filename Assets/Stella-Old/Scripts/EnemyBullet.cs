using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]private GameObject player;
    private Rigidbody2D rb;
    public float speed;
    private float projectilelife;
    public int damage;

    private void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();

        //Die Richtung des Spielers bzw. damit das Projektile in die Richtung des Spielers fliegt
        Vector2 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * speed;


    }

    private void Update()
    {
        projectilelife += Time.deltaTime;
        //Projektile verschwindet nach einer gewissenen Zeit
        if(projectilelife > 6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Player>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
