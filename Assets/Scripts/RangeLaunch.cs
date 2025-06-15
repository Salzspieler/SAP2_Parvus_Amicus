using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;  // Für UI-Komponenten

public class RangeLaunch : MonoBehaviour
{
    [SerializeField] private GameObject aphidObject;
    public Transform launchPoint;
    //private GameObject player;
    //[SerializeField] Sprite newSprite;
    private Animator playeranimator;
    private bool ReadytoLaunch = false;
    private Player player;

    //public bool throwready; 

    public float shootTime; // Cooldown zwischen den werfen
    public float shootCounter; // Cooldown Zeit

    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
        playeranimator = GameObject.Find("Player").GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>(); 
        //player = GameObject.Find("Player");
        //throwready = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (player.aphidCounter == 1)
        {
            ReadytoLaunch = true;
            playeranimator.SetBool("Launch", ReadytoLaunch);
            playeranimator.SetBool("HasAphid", true);
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && shootCounter < 0 && ReadytoLaunch)
        {
            //ReadytoLaunch = true;
            //Debug.Log("RangeLaunch");
            player.aphidCounter--;
            Debug.Log("Counter" + player.aphidCounter);
            ReadytoLaunch = false;
            playeranimator.SetBool("Launch", ReadytoLaunch);
            Instantiate(aphidObject, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
            playeranimator.SetBool("HasAphid", false);
        }

        

        
        //Debug.Log("Nach Update RangeLaunch");
        
        //player.currentSprite = newSprite;
        //Debug.Log("Sprite ändern");
        shootCounter -= Time.deltaTime;
        if (shootCounter < 0)
        {
            player.aphidCounter = 1;

            
        }

        //if(aphidCounter == 0){
        //playeranimator.SetBool("HasAphid", false);
        //}

    }





}
