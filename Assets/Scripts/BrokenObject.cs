using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrokenObject : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            // Kamera wackeln lassen
            //StartCoroutine(CameraShake.instance.Shake(0.3f, 0.2f));

            // Objekt zerstören
            Destroy(gameObject);
        }
        
    }



}
