using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Aphid : MonoBehaviour
{
    public Rigidbody2D aphidRB;
    public float speed;
    public int damage = 1;
    public Player player;
    public float aphidLife; // wie lange die Blattlaus lebt
    public float aphidCount; //z�hlt runter wann die Blattlaus zerst�rt wird
    public bool facingRight;
    [SerializeField] private AudioClip TrefferSound;



    private void Start()
    {
        aphidCount = aphidLife;
        player = GameObject.Find("Player").GetComponent<Player>();
        aphidRB = GetComponent<Rigidbody2D>();
        facingRight = player.facingRight;
        if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Update()
    {
        aphidCount -= Time.deltaTime;

        if (aphidCount <= 0)
        {
            Destroy(gameObject);
        }
    }



    private void FixedUpdate()
    {
        if (facingRight)
        {
            aphidRB.velocity = new Vector2(speed, aphidRB.velocity.y);
        }
        else
        {
            aphidRB.velocity = new Vector2(-speed, aphidRB.velocity.y);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") == true)
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
            SoundManager.instance.PlaySound(TrefferSound);
        }

        if (collision.gameObject.CompareTag("FlyingEnemy") == true)
        {
            collision.gameObject.GetComponent<FlyingEnemy>().TakeDamage(damage);
            SoundManager.instance.PlaySound(TrefferSound);
        }

        if (collision.gameObject.CompareTag("HardEnemy") == true)
        {
            collision.gameObject.GetComponent<HeavyEnemy>().TakeDamage(damage);
            SoundManager.instance.PlaySound(TrefferSound);
        }

        if (collision.gameObject.CompareTag("Boss") == true)
        {
            collision.gameObject.GetComponent<Boss>().TakeDamage(damage);
            SoundManager.instance.PlaySound(TrefferSound);
        }
        Destroy(gameObject);
    }
}
