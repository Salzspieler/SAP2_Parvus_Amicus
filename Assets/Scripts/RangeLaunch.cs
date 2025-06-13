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
    private bool launchInProgress = false;

    //public bool throwready; 

    public float shootTime; // Cooldown zwischen den werfen
    public float shootCounter; // Cooldown Zeit

    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
        //player = GameObject.Find("Player");
        //throwready = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && shootCounter < 0)
        {
            launchInProgress = true;
            Instantiate(aphidObject, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;

            
            //player.GetComponent<Renderer>().sp = newSprite;
            /*if(shootCounter >= 0)
            {
                player.GetComponent<SpriteRenderer>().sprite = newSprite;
            }*/
            
        }
        launchInProgress = false;
        //player.currentSprite = newSprite;
        //Debug.Log("Sprite ändern");
        shootCounter -= Time.deltaTime;

        /*if (shootCounter < 0)
        {
            //Debug.Log("Sprite Changer");
            player.GetComponent<SpriteRenderer>().sprite = player.GetComponent<Player>().currentSprite;
        }*/
        //Sprite Change´mit Aphid Counter
        
    }


    public bool GetLaunch()
    {
        return launchInProgress;
    }



}
