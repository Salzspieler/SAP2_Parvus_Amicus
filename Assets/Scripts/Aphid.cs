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
    //private Logic logic;
    public bool facingRight;
    [SerializeReference]private Sprite newSprite;



    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        //logic = GameObject.Find("Logic").GetComponent<Logic>();
        aphidRB = GetComponent<Rigidbody2D>();
        facingRight = player.facingRight;
        if (!facingRight)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        
    }

    private void Update()
    {
        /*aphidCount -= Time.deltaTime;

        if(aphidCount == 1)
        {
            Debug.Log("Counter: "+aphidCount);
            Destroy(gameObject);
        }*/
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(aphidCount == 1)
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
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){

            Collect();
        }
    }




    void Collect()
    {
        aphidCount = 1f;
        
        //transform.SetParent(transform, true);
        // optisch ausschalten
        GetComponent<Renderer>().enabled = false;
        gameObject.SetActive(false);
        player.GetComponent<SpriteRenderer>().sprite = newSprite;
        //Destroy(gameObject);


        //print("Collect");
    }

}
