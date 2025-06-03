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
    public float aphidCount; //zählt runter wann die Blattlaus zerstört wird
    [SerializeReference]private Sprite newSprite;
    public bool facingRight;



    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        aphidRB = GetComponent<Rigidbody2D>();
        facingRight = player.facingRight;
        if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
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
        }
        Destroy(gameObject);
    }





}
