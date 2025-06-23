using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;
    public bool isGrounded = false;
    public float jumpHeight = 5f;
    public int maxHealth=3;
    public int currentHealth;
    public Animator animator;
    [SerializeField]private GameObject dashPoint;
    [SerializeField]private GameObject npc;
    private enum animState {idle, walk,jump, fall, hover }
    private enum animState2 {idle,walk,jump, fall, hover, heal, _throw }
    private animState state;
    private animState2 state2;
    public int aphidCounter;

    private bool canDoubleJump = false;
    public bool facingRight;

    public float normalyGravity = 3f;
    public float glideGravity = 0.05f;

    public float KBForce; //wie viel Kraft auf den Spieler gewirkt wird
    public float KBCounter; //
    public float KBTotalTime; //wie lange die Kraft auf den Spieler wirkt

    public bool KnockFromRight;

    private Logic logic;
    [SerializeField] private float dashspeed;
    public bool isDashButtonDown = false;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = gameObject.GetComponent<Animator>();
        logic = GameObject.Find("CollectableLogic").GetComponent<Logic>();
        npc = GameObject.Find("OldManSprite");
        rb.gravityScale = normalyGravity;
        if(npc == null)
        {
            return;
        }
    }

    void Update()
    {
        if ( npc == null || !npc.GetComponent<NPCs>().isTalking)
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
            if (!isGrounded && rb.velocity.y < 0 && Input.GetKey(KeyCode.Space))
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
            if (Input.GetKey(KeyCode.LeftShift))
            {

                transform.position = Vector2.MoveTowards(transform.position, dashPoint.transform.position, Time.deltaTime * dashspeed);

            }

            //heilen
            if (Input.GetKeyDown(KeyCode.Q) && logic.leavesCount > 0)
            {
                if (currentHealth < maxHealth)
                {
                    animator.SetTrigger("Heal");
                }

            }


            //tanzen
            if (Input.GetKeyDown(KeyCode.T))
            {
                print("TanzButton");
            }

            //Animations Logic ohne Fifi

            //idle
            if (isGrounded && !animator.GetBool("HasAphid"))
            {
                state = animState.idle;
                animator.SetFloat("state_1", 0);
            }

            //run
            if (isGrounded && (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) && !animator.GetBool("HasAphid"))
            {
                state = animState.walk;
                animator.SetFloat("state_1", 1);
            }

            //jump
            if (!isGrounded && rb.velocity.y > 0 && !animator.GetBool("HasAphid"))
            {
                state = animState.jump;
                animator.SetFloat("state_1", 2);
                //Debug.Log("Jump Animation");
            }

            //fall
            if (!isGrounded && rb.velocity.y <= 0 && !animator.GetBool("HasAphid"))
            {
                state = animState.fall;
                animator.SetFloat("state_1", 3);
            }

            //hover
            if (!isGrounded && rb.velocity.y <= 0 && Input.GetKey(KeyCode.Space) && !animator.GetBool("HasAphid"))
            {
                state = animState.hover;
                animator.SetFloat("state_1", 4);
            }

            //Animations Logic mit Fifi

            //idle
            if (isGrounded && animator.GetBool("HasAphid"))
            {
                state2 = animState2.idle;
                animator.SetFloat("state_2", 0);
            }

            //run
            if (isGrounded && (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0) && animator.GetBool("HasAphid"))
            {
                state2 = animState2.walk;
                animator.SetFloat("state_2", 1);
            }

            //jumps
            if (!isGrounded && rb.velocity.y > 0 && animator.GetBool("HasAphid"))
            {
                state2 = animState2.jump;
                animator.SetFloat("state_2", 2);
            }

            //fall
            if (!isGrounded && rb.velocity.y <= 0 && animator.GetBool("HasAphid"))
            {
                state2 = animState2.fall;
                animator.SetFloat("state_2", 3);
            }

            //hover
            if (!isGrounded && rb.velocity.y <= 0 && animator.GetBool("HasAphid") && Input.GetKey(KeyCode.Space))
            {
                state2 = animState2.hover;
                animator.SetFloat("state_2", 4);
            }

            //tanzen

            animator.SetFloat("state_1", (float)state);
            animator.SetFloat("state_2", (float)state2);

        }


    }

    //heilen Funktion
    public void Healing()
    {
        logic.leavesCount--;
        logic.leavesText.text = logic.leavesCount.ToString();
        state2 = animState2.heal;
        animator.ResetTrigger("Heal");
        currentHealth++;
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
}
