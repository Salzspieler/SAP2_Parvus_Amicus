using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogTrigger : MonoBehaviour
{
    public GameObject dialogBox;
    public TMP_Text dialogText;
    public string message = "Drücke jetzt Linksklick, um zu gleiten!";
    public float showTime = 3f;

    public WayPointFollower npc; // ← Zieh den NPC mit dem WayPointFollower hier rein

    //private void Start()
    //{
    //    StartCoroutine(StartDialogAndMove());
    //}

    public void StartDialog()
    {
        print("Start Dialog");
        dialogBox.SetActive(true);
        dialogText.text = message;

        //yield return new WaitForSeconds(showTime);

        dialogBox.SetActive(false);
        npc.canMove = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartDialog();


        }
    }
}
