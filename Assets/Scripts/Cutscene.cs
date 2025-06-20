using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    
    private GameObject player;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.Find("Player");
        //player.GetComponent<Rigidbody2D>().simulated = false;
        //player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Animator>().SetTrigger("StartCutscene");

    }


    public void CutsceneEnd()
    {
        //player.GetComponent<Rigidbody2D>().simulated = true;
        //player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<Animator>().ResetTrigger("StartCutscene");
    }
    

}
