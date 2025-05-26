using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private Player player;

    public float damagePerSecond = 1f;    // Schaden pro Sekunde
    public float sinkSpeed = 2f;          // Sinkgeschwindigkeit
    private float damageTimer = 0f;
    private bool isInWater = false;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        if (isInWater)
        {
            // Schaden alle Sekunde
            damageTimer += Time.deltaTime;
            if (damageTimer >= 1f)
            {
                player.TakeDamage((int)damagePerSecond);
                damageTimer = 0f;
            }

            // Spieler langsam nach unten ziehen
            player.transform.position += Vector3.down * sinkSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInWater = true;
            damageTimer = 0f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInWater = false;
            damageTimer = 0f;
        }
    }
}
