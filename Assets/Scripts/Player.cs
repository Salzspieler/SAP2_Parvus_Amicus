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
    public Healthbar healthbar;
    public Animator animator;
    private RangeLaunch rangeLaunch;
    private enum animState { idle, jump, fall, hover }
    private enum animState2 { idle, jump, throwAphid, hover, fall, heal }
    private animState state;
    private animState2 state2;



    private bool canDoubleJump = false;
    public bool facingRight;

    public float normalyGravity = 3f;
    public float glideGravity = 0.05f;

    public float KBForce; //wie viel Kraft auf den Spieler gewirkt wird
    public float KBCounter; //
    public float KBTotalTime; //wie lange die Kraft auf den Spieler wirkt

    public bool KnockFromRight;

    //public Sprite currentSprite;
    private CollectableLogic logic;
    [SerializeField] private float dashspeed;
    public bool isDashButtonDown = false;
    //public float dashTime;
    //public float dashCounter;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        animator = GetComponent<Animator>();
        //currentSprite = GetComponent<SpriteRenderer>().sprite;
        logic = GameObject.Find("CollectableLogic").GetComponent<CollectableLogic>();
        //dashCounter = dashTime;
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
            state = animState.idle;
        }
        else
        {
            state2 = animState2.idle;
        }

        //jump
        if (!isGrounded && rb.velocity.y > 0 && !animator.GetBool("HasAphid"))
        {
            state = animState.jump;
            Debug.Log("Jump Animation");
        }
        else
        {
            state2 = animState2.jump;
        }

        //fall
        if (!isGrounded && rb.velocity.y <= 0 && !animator.GetBool("HasAphid"))
        {
            state = animState.fall;
        }
        else
        {
            state2 = animState2.fall;
        }

        //hover
        if (!isGrounded && rb.velocity.y <= 0 && Input.GetKey(KeyCode.LeftControl) /*Input.GetKey(KeyCode.E)*/ && !animator.GetBool("HasAphid"))
        {
            state = animState.hover;
        }
        else
        {
            state2 = animState2.hover;
        }

        //throw
        if (rangeLaunch.GetLaunch())
        {
            state2 = animState2.throwAphid;
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
        //Debug.Log("Healing");

        //Debug.Log("If Healing");
        logic.leavesCount--;
        state2 = animState2.heal;
        currentHealth++;
        healthbar.SetHealth(currentHealth);
        animator.SetFloat("state2", (float)state2);
        //Debug.Log("Leaves: " + logic.leavesCount);

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
        animator.SetTrigger("Hit");
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


    /*
     * Input mit Shift-Taste
     * Dash mit Rigidbody, Multiplizieren mit dashspeed und deltaTime
     * Dashspeed muss höher sein als Speed
     */
}
