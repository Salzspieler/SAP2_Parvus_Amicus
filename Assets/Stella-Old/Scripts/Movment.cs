using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Movment : MonoBehaviour

{
    public Transform[] waypoints;
    public float speed = 2f;
    private int currentWaypointIndex = 0;
    private bool dialogueFinished = false;
    private bool isMoving = false;

    public GameObject dialogBox;           // Panel mit Textbox
    public TMP_Text dialogText;            // Der Text in der Box
    public float hintDuration = 3f;
    private bool hintShown = false;

    void Update()
    {
        // Beispiel: E beendet Dialog und startet Bewegung
        if (Input.GetKeyDown(KeyCode.E))
        {
            dialogueFinished = true;
            isMoving = true;
        }

        if (dialogueFinished && !hintShown)
        {
            ShowHint("Jetzt Linksklick drücken zum Gleiten!");
        }

        if (isMoving && currentWaypointIndex < waypoints.Length)
        {
            MoveToNextWaypoint();
        }
    }

    void MoveToNextWaypoint()
    {
        Transform target = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            currentWaypointIndex++;
        }
    }

    void ShowHint(string message)
    {
        dialogBox.SetActive(true);
        dialogText.text = message;
        Invoke("HideHint", hintDuration);
        hintShown = true;
    }

    void HideHint()
    {
        dialogBox.SetActive(false);
    }
}
