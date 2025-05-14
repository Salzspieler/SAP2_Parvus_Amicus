using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Aphid : MonoBehaviour
{
    public Rigidbody2D aphidRB;
    public int damage = 1;
    public Player player;
    public float aphidLife;
    public float aphidCount;
    public float speed;
    private Logic logic;
    public bool facingRight;


    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        logic = GameObject.Find("Logic").GetComponent<Logic>();
        aphidRB = GetComponent<Rigidbody2D>();
        facingRight = player.facingRight;
        
    }

    private void Update()
    {
        /*aphidCount -= Time.deltaTime;

        if(aphidCount == 1)
        {
            Destroy(gameObject);
        }*/
    }
    // Update is called once per frame
    void FixedUpdate()
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Collect();
        }
    }

   


    void Collect()
    {
        // optisch ausschalten
        GetComponent<Renderer>().enabled = false;
        gameObject.SetActive(false);


        //print("Collect");
    }

}
