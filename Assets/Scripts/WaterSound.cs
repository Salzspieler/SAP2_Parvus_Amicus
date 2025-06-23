using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class WaterSound : MonoBehaviour
{
    [SerializeField] private AudioClip Water1Sound;
    float volume = 1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(Water1Sound, volume = 0.05f);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
          if(collision.gameObject.CompareTag("Player"))
        {
            Water1Sound.UnloadAudioData();
        }
    }

}
