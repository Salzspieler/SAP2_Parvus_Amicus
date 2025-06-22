using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGTALK;

public class NPCs : MonoBehaviour
{
    [SerializeField] private RPGTalk _talkText1;
    //[SerializeField] private RPGTalk _talkText2;
    //[SerializeField] private RPGTalk _talkText3;
    [SerializeField] private bool alreadyTalked = false;
    [SerializeField] private bool talkTextBool1 = false;
    [SerializeField] private bool talkTextBool2 = false;
    [SerializeField] private bool talkTextBool3 = false;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private int currentWaypointIndex = 0;
    [SerializeField] private float speed;



    private void Awake()
    {
        _talkText1 = GetComponent<RPGTalk>();
        player = GameObject.Find("Player");
    }





    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!alreadyTalked && !talkTextBool1)
            {
                print("TalkText1");
                _talkText1.enabled = true;
                talkTextBool1 = true;
                _talkText1.NewTalk();
                other.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            }
        }

        
            /*
            else if (!alreadyTalked && talkTextBool1 && !talkTextBool2 && !talkTextBool3)
            {
                _talkText2.enabled = true;
                talkTextBool2 = true;
                _talkText2.NewTalk();
                other.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            }
            else if (!alreadyTalked && talkTextBool1 && talkTextBool2 && !talkTextBool3)
            {
                _talkText3.enabled = true;
                talkTextBool3 = true;
                _talkText3.NewTalk();
                other.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            }
            */
    }



    public void FirstConversation()
    {
        alreadyTalked = true;
        _talkText1.enabled = false;
        player.GetComponent<Rigidbody2D>().simulated = true;
    }

    //private void SecondConversation()
    //{
    //    _talkText2.enabled = true;
    //}

    //private void ThirdConversation()
    //{
    //    _talkText3.enabled = true;
    //}
}
