using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeLaunch : MonoBehaviour
{
    public GameObject aphidObject;
    public Aphid aphid;
    public Transform launchPoint;
    public GameObject[] clonedObjects; //Seriliazed


    // Start is called before the first frame update
    void Start()
    {
        aphidObject = GameObject.Find("Aphid");
        aphid = GameObject.Find("Aphid").GetComponent<Aphid>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && aphid.aphidCount == 1)
        {
            Instantiate(aphidObject, launchPoint.position, Quaternion.identity);
            GetComponent<Renderer>().enabled = true;
            aphidObject.SetActive(true);
            aphid.aphidCount=0f;
            
            
        }
        
    }
}

