using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeLaunch : MonoBehaviour
{
    public GameObject aphidObject;
    public Transform launchPoint;
    

    // Start is called before the first frame update
    void Start()
    {
        aphidObject = GameObject.Find("Aphid");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(aphidObject, launchPoint.position, Quaternion.identity);
            
        }
        
    }
}

