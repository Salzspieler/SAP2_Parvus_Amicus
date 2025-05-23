using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeLaunch : MonoBehaviour
{
    [SerializeField]private GameObject aphidObject;
    public Transform launchPoint;
    //public float shootTime;
    //public float shootCounter;
    //[SerializeField]private GameObject[] clonedObjects; //Seriliazed


    // Start is called before the first frame update
    void Start()
    {
        aphidObject = GameObject.Find("Aphid");
        //shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && aphidObject.GetComponent<Aphid>().aphidCount == 1)
        {
            aphidObject.transform.position = launchPoint.position;
            //aphidObject.GetComponent<Aphid>().aphidRB.velocity = new Vector2( *aphidObject.GetComponent<Aphid>().speed, aphidObject.GetComponent<Aphid>().aphidRB.velocity.y); Blattlaus werfen fehlt
            //aphidObject.transform.SetParent(transform, false);
            //Instantiate(aphidObject, launchPoint.position, Quaternion.identity);
            //shootTime = shootCounter;
            aphidObject.GetComponent<Renderer>().enabled = true;
            aphidObject.SetActive(true);
            aphidObject.GetComponent<Aphid>().aphidCount=0f;
            
            
        }
        //shootCounter -= Time.deltaTime;
        
    }
}

