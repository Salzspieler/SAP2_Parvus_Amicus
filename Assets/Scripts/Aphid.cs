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
    [SerializeReference]private Sprite newSprite;



    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        aphidRB = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){

            Collect();
        }
        /*
         * if(collision.gameObject.){
         * }
         */
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
