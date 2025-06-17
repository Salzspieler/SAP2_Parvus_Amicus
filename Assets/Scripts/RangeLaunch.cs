using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;  // Für UI-Komponenten

public class RangeLaunch : MonoBehaviour
{
    [SerializeField] private GameObject aphidObject;
    public Transform launchPoint;
    private Animator playeranimator;
    private Player player;

    public float shootTime; // Cooldown zwischen den werfen
    public float shootCounter; // Cooldown Zeit

    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
        playeranimator = GameObject.Find("Player").GetComponent<Animator>();
        player = GameObject.Find("Player").GetComponent<Player>(); 

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && shootCounter < 0 /*&& ReadytoLaunch*/)
        {
            //Debug.Log("ReadytoLaunch bevor Animation: " + ReadytoLaunch);
            playeranimator.SetBool("Launch", true);
            //ReadytoLaunch = true;
            //Debug.Log("RangeLaunch");
            //player.aphidCounter--;
            //Debug.Log("Counter" + player.aphidCounter);
            //ReadytoLaunch = false;
            //playeranimator.SetBool("Launch", false);
            //Debug.Log("ReadytoLaunch: " + ReadytoLaunch);
            Instantiate(aphidObject, launchPoint.position, Quaternion.identity);
            //shootCounter = shootTime;
            
        }
        shootCounter -= Time.deltaTime;

        if(shootCounter > 0)
        {
            playeranimator.SetBool("Launch", false);
            playeranimator.SetBool("HasAphid", false);
        }
        if (shootCounter < 0)
        {
            //player.aphidCounter = 1;
            playeranimator.SetBool("HasAphid", true);
            //Debug.Log("Blattlaus ist wieder da");

        }

    }

    public void SetShootCounter()
    {
        shootCounter = shootTime;
    }



}
