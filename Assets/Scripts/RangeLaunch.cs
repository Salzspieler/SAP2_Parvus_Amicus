using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;  // Für UI-Komponenten

public class RangeLaunch : MonoBehaviour
{
    [SerializeField] private GameObject aphidObject;
    [SerializeField] private Player player;
    public Transform launchPoint;
    private Animator playeranimator;
    public bool readytoShoot = false;


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
        if (player.aphidCounter == 1)
        {
            readytoShoot = true;
        }
        if (readytoShoot)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && shootCounter < 0)
            {
                playeranimator.SetTrigger("Shoot");
                shootCounter = shootTime;
            }
            shootCounter -= Time.deltaTime;


            if (shootCounter > 0)
            {
                playeranimator.SetBool("HasAphid", false);
                readytoShoot = false;
            }
            if (shootCounter < 0)
            {
                playeranimator.ResetTrigger("Shoot");
                playeranimator.SetBool("HasAphid", true);
                readytoShoot = true;
            }
        } 
    }


    public void Throw()
    {
       Instantiate(aphidObject, launchPoint.position, Quaternion.identity);
       
    }


    /*
    public void SetShootCounter()
    {
        shootCounter = shootTime;
    }
    */


}
