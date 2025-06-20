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


    public float shootTime; // Cooldown zwischen den werfen
    public float shootCounter; // Cooldown Zeit

    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
        playeranimator = GameObject.Find("Player").GetComponent<Animator>();

    }

    

    // Update is called once per frame
    void Update()
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
        }
        if (shootCounter < 0)
        {
            playeranimator.ResetTrigger("Shoot");
            playeranimator.SetBool("HasAphid", true);
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
