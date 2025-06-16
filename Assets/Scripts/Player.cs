using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public bool isGrounded = false;
    public float jumpHeight = 5f;
    public int maxHealth = 5;
    public int currentHealth;
    public Animator animator;
    private RangeLaunch rangeLaunch;
    private enum animState {idlewalk,jump, fall, hover }
    private enum animState2 {idlewalk,jump, hover, fall, heal}
    private animState state;
    private animState2 state2;
    public int aphidCounter = 1;
    



    private bool canDoubleJump = false;
    public bool facingRight;

    public float normalyGravity = 3f;
    public float glideGravity = 0.05f;

    public float KBForce; //wie viel Kraft auf den Spieler gewirkt wird
    public float KBCounter; //
    public float KBTotalTime; //wie lange die Kraft auf den Spieler wirkt

    public bool KnockFromRight;

    private CollectableLogic logic;
    [SerializeField] private float dashspeed;
    public bool isDashButtonDown = false;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = gameObject.GetComponent<Animator>();
        logic = GameObject.Find("CollectableLogic").GetComponent<CollectableLogic>();
        rangeLaunch = GetComponent<RangeLaunch>();

        rb.gravityScale = normalyGravity;
    }

    void Update()
    {

        if (KBCounter <= 0)
        {
            // Bewegung
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        }
        else
        {
            if (KnockFromRight == true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight == false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }



        // Sprung & Double Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
                canDoubleJump = false;
            }
        }

        // Gleiten (nur beim Fallen)
        if (!isGrounded && rb.velocity.y < 0 && Input.GetKey(KeyCode.LeftControl) /*Input.GetKey(KeyCode.E)*/)
        {
            rb.gravityScale = glideGravity;
        }
        else
        {
            rb.gravityScale = normalyGravity;
        }

        // Drehrichtung
        if (Input.GetAxis("Horizontal") > 0)
        {
            facingRight = true;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            facingRight = false;
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("Dash");
            //dashCounter = dashTime;
            isDashButtonDown = true;
            //Debug.Log(isDashButtonDown);
        }
        //dashCounter -= Time.deltaTime;

        //heilen
        if (Input.GetKeyDown(KeyCode.Q) && logic.leavesCount > 0)
        {
            if (currentHealth < maxHealth)
            {
                Healing();
            }

        }

        //Animations Logic ohne Fifi

        //run
        if (isGrounded && Input.GetAxis("Horizontal") == 0 && !animator.GetBool("HasAphid"))
        {
            state = animState.idlewalk;
            animator.SetFloat("xVelocity", rb.velocity.x);
        }
        
        else 
        {
            state2 = animState2.idlewalk;
            animator.SetFloat("xVelocity", rb.velocity.x);
        }
        

        //jump
        if (!isGrounded && rb.velocity.y > 0 && !animator.GetBool("HasAphid"))
        {
            state = animState.jump;
            //Debug.Log("Jump Animation");
        }
        if (!isGrounded && rb.velocity.y > 0 && animator.GetBool("HasAphid"))
        {
            state2 = animState2.jump;
        }

        //fall
        if (!isGrounded && rb.velocity.y <= 0 && !animator.GetBool("HasAphid"))
        {
            state = animState.fall;
        }
        if(!isGrounded && rb.velocity.y <= 0)
        {
           state2 = animState2.fall;
        }

        //hover
        if (!isGrounded && rb.velocity.y <= 0 && Input.GetKey(KeyCode.LeftControl) /*Input.GetKey(KeyCode.E)*/ && !animator.GetBool("HasAphid"))
        {
            state = animState.hover;
        }
        if (!isGrounded && rb.velocity.y <= 0 && Input.GetKey(KeyCode.LeftControl))
        {
            state2 = animState2.hover;
        }

        animator.SetInteger("state", (int)state);
        animator.SetInteger("state2", (int)state2);

    }

    private void FixedUpdate()
    {
        if (isDashButtonDown)
        {
            //Debug.Log("Dash Fixed");
            rb.velocity = new Vector2(transform.localScale.x * dashspeed * Time.fixedDeltaTime, 0f);
            isDashButtonDown = false;
        }
    }

    //heilen Funktion
    public void Healing()
    {
        logic.leavesCount--;
        logic.leavesText.text = logic.leavesCount.ToString();
        state2 = animState2.heal;
        currentHealth++;
        animator.SetInteger("state2", (int)state2);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        
        if(!animator.GetBool("HasAphid"))
        {
            animator.SetTrigger("Hit");
            print("HasAphidTriggerFalse");
        }
        else
        {
            animator.SetTrigger("Hit");
            print("HasAphidTriggerTrue");
        }
        if (currentHealth <= 0)
        {
            Restart();
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Ground Check
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            rb.gravityScale = normalyGravity;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
