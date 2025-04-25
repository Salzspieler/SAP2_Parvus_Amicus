using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public bool isGrounded = false;
    public float jumpHeight = 5f;
    public int maxHealth = 5;
    public int currentHealth;
    public Healthbar healthbar;
    public bool CollideHalfObject = false;
    public BrokenObject brokenObject;
    public int jumps = 0;
    public int maxjumps = 2;
    public bool isWater = false;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //Movement
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        //jump

        
        if (isGrounded)
        {
            jumps = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) /*&& isGrounded*/ && jumps < maxjumps)
        {
            Debug.Log("Vor Jump: " + jumps);
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            jumps++;
            Debug.Log("jumpcounter: " + jumps);
            //rb.velocity = Vector2.up * speed;
        }
        //3 Jumps    
       
        //spin
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(isWater == true)
        {
            WaterDamage();
        }

        
    }


    public void SpikeDamage(int damage)
    {
        currentHealth -= damage;

        healthbar.SetHealth(currentHealth);

        if(currentHealth == 0)
        {
            Restart();
        }
    }

    public void WaterDamage()
    {
        Restart();
    }




    //groundCheck
    void OnCollisionEnter2D(Collision2D other)
    {
        //check anderes Objekt ob es Ground ist
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            //animator.SetBool("isGrounded", true);
        }

        if (other.gameObject.CompareTag("Water"))
        {
            isWater = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        //animator.SetBool("isGrounded", false);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
