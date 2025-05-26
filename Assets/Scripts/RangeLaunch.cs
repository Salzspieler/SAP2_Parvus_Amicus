using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;  // Für UI-Komponenten

public class RangeLaunch : MonoBehaviour
{
    [SerializeField] private GameObject aphidObject;
    private Player player;
    public Transform launchPoint;

    public float minForce;
    public float maxForce;
    public float chargeSpeed;

    private float currentForce;
    private bool isCharging = false;

    // UI PowerBar
    public Image powerBarImage;

    void Start()
    {
        aphidObject = GameObject.Find("Aphid");
        player = GameObject.Find("Player").GetComponent<Player>();
        if (powerBarImage != null)
        {
            powerBarImage.fillAmount = 0f;
        }
            
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && aphidObject.GetComponent<Aphid>().aphidCount == 1)
        {
            currentForce = minForce;
            isCharging = true;
        }

        //Wurf aufladen
        if (Input.GetKey(KeyCode.Mouse1) && isCharging)
        {
            currentForce += chargeSpeed * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, minForce, maxForce);

            // PowerBar füllen
            if (powerBarImage != null)
            {
                powerBarImage.fillAmount = (currentForce - minForce) / (maxForce - minForce);
            }
                
        }

        if (Input.GetKeyUp(KeyCode.Mouse1) && isCharging)
        {
            ThrowAphid();
            isCharging = false;
            //aphidObject.GetComponent<Aphid>().aphidLife -= Time.deltaTime;
            /*if (aphidObject.GetComponent<Aphid>().aphidLife == 0)
            {
                GetComponent<Renderer>().enabled = false;
                gameObject.SetActive(false);
            }*/
            // PowerBar leeren
            if (powerBarImage != null)
            {
                powerBarImage.fillAmount = 0f;
            }
                
        }
    }

    void ThrowAphid()
    {
        aphidObject.transform.position = launchPoint.position;
        aphidObject.SetActive(true);
        aphidObject.GetComponent<Renderer>().enabled = true;
        player.GetComponent<SpriteRenderer>().sprite = player.currentSprite;

        Rigidbody2D rb = aphidObject.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;

        float facingDir = transform.localScale.x > 0 ? 1f : -1f;

        Vector2 direction;
        //Nach oben werfen
        if (Input.GetKey(KeyCode.W))
        {
            direction = Vector2.up;
        }
        
        /*
        else if (Input.GetKey(KeyCode.S))
        {
            direction = Vector2.right * facingDir;
        }
        */
        else
        {
            direction = (Vector2.right * facingDir + Vector2.up * 0.5f).normalized;
        }
        rb.AddForce(direction * currentForce, ForceMode2D.Impulse);

        aphidObject.GetComponent<Aphid>().aphidCount = 0;
    }



}
