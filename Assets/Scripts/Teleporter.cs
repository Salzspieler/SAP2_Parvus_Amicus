using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Teleporter : MonoBehaviour
{
    public Transform target;
    private bool canTeleport = true;
    private bool isPlayerInRange = false;
    // Zeit, die der Spieler im Bereich ist
    private float timeInRange = 0f;  
                                  
    
    // Zeit, die der Spieler im Bereich bleiben muss, bevor teleportiert wird
    public float waitTime = 1f;
  
    // Cooldown nach dem Teleport
    public float cooldownTime = 0.5f;  

    private void Update()
    {
        // Wenn der Spieler im Bereich ist, zähle die Zeit
        if (isPlayerInRange)
        {

            // Zeit hochzählen
            timeInRange += Time.deltaTime; 

            // Wenn genug Zeit im Bereich war und der Spieler immer noch da ist
            if (timeInRange >= waitTime && canTeleport)
            {
                // Teleportiere den Spieler und starte den Cooldown
                StartCoroutine(TeleportCooldown());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canTeleport)
        {
            // Wenn der Spieler in den Teleporterbereich geht, beginne mit der Zeitzählung
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Wenn der Spieler den Bereich verlässt, setze alles zurück
            isPlayerInRange = false;
           
            // Reset der Zeit
            timeInRange = 0f; 
        }
    }

    private IEnumerator TeleportCooldown()
    {
        // Deaktiviert den Teleport
        canTeleport = false;  

        // Teleportiere den Spieler
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = target.position;

        // Warte die Cooldown-Zeit ab
        yield return new WaitForSeconds(cooldownTime);
       
        // Teleport wieder aktivieren
        canTeleport = true;
       
        // Reset der Zeit
        timeInRange = 0f;  
    }
}
