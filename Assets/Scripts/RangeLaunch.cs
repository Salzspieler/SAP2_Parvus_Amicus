using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;  // Für UI-Komponenten

public class RangeLaunch : MonoBehaviour
{
    [SerializeField] private GameObject aphidObject;
    public Transform launchPoint;
    private Player player;
    [SerializeField] Sprite newSprite;

    public float shootTime; // Cooldown zwischen den werfen
    public float shootCounter; // Cooldown Zeit

    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootTime;
        player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && shootCounter < 0)
        {
            Instantiate(aphidObject, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
        }
        
        //player.currentSprite = newSprite;
        //Debug.Log("Sprite ändern");
        shootCounter -= Time.deltaTime;

        if(shootCounter < shootTime)
        {
            player.currentSprite = newSprite;
        }
        
    }



}
