using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGTALK;

public class NPCs : MonoBehaviour
{
    [SerializeField] private RPGTalk _talkText1;
    [SerializeField] private RPGTalk _talkText2;
    [SerializeField] private RPGTalk _talkText3;
    [SerializeField] private bool alreadyTalked = false;
    [SerializeField] private bool talkTextBool1 = false;
    [SerializeField] private bool talkTextBool2 = false;
    [SerializeField] private bool talkTextBool3 = false;
    [SerializeField] private bool isPaused = true;
    public bool isTalking = false;
    [SerializeField] private GameObject player;
    [SerializeField] private RangeLaunch rangeLaunch;
    [SerializeField] private GameObject[] wayPoints;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Logic logic;
    public GameObject target;
    [SerializeField] private int currentWaypointIndex = 0;
    [SerializeField] private float speed;
    
    



    private void Awake()
    {

        player = GameObject.Find("Player");
        rangeLaunch = GameObject.Find("Player").GetComponent<RangeLaunch>();
        target = wayPoints[currentWaypointIndex];
        logic = GameObject.Find("CollectableLogic").GetComponent<Logic>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (!isPaused)
        {
            //next Waypoint logic
            MoveToNextWaypoint();


            if (currentWaypointIndex == 13 && !talkTextBool2)
            {
                isPaused = true;
                MoveToNextWaypoint();


            }

            if (currentWaypointIndex == 28 && !talkTextBool3)
            {
                isPaused = true;
            }
        }
    }





    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            switch (currentWaypointIndex)
            {
                //erster Dialog starten
                case 0:
                    print("TalkText1");
                    _talkText1.enabled = true;
                    talkTextBool1 = true;
                    _talkText1.NewTalk();
                    rangeLaunch.readytoShoot = false;
                    isTalking = true;
                    other.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                    break;
                //zweiter Dialog starten
                case 13:
                    talkTextBool2 = true;
                    _talkText2.enabled = true;
                    _talkText2.NewTalk();
                    rangeLaunch.readytoShoot = false;
                    isTalking = true;
                    other.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                    print("MiddlePoint");
                    break;
                //dritter Dialog starten
                case 28:
                    talkTextBool3 = true;
                    _talkText3.enabled = true;
                    _talkText3.NewTalk();
                    isPaused = true;
                    isTalking = true;
                    other.gameObject.GetComponent<Rigidbody2D>().simulated = false;
                    print("EndPoint");
                    break;

                default: return;
            }
        }
    }


    //erster Dialog 
    public void FirstConversation()
    {
        alreadyTalked = true;
        _talkText1.enabled = false;
        isPaused = false;
        rangeLaunch.readytoShoot = true;
        isTalking = false;
        player.GetComponent<Rigidbody2D>().simulated = true;
    }

    //zweiter Dialog
    public void SecondConversation()
    {
        alreadyTalked = true;
        _talkText2.enabled = false;
        isPaused = false;
        rangeLaunch.readytoShoot = true;
        isTalking = false;
        player.GetComponent<Rigidbody2D>().simulated = true;
    }

    //dritter Dialog
    public void ThirdConversation()
    {
        alreadyTalked = true;
        _talkText3.enabled = false;
        isPaused = false;
        rangeLaunch.readytoShoot = true;
        isTalking = false;
        player.GetComponent<Rigidbody2D>().simulated = true;
        player.GetComponent<Player>().aphidCounter = 1;
        logic.leavesCount += 2;
        logic.leavesText.text = logic.leavesCount.ToString();
        Destroy(gameObject);
    }

    //zum nächsten Waypoint
    private void MoveToNextWaypoint()
    {
       
        if (Vector2.Distance(transform.position, target.transform.position) < .1f)
        {
            currentWaypointIndex++;
            
            if (currentWaypointIndex <= 27)
            {
                target = wayPoints[currentWaypointIndex];
            }
        }

        //moveLogic
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        }
        
    
}
