using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowWithCooldown : MonoBehaviour
{
    public Image cooldownOverlay;
    public Image blackOverlay;

    public float cooldownTime = 3f;
    private float cooldownTimer = 0f;

    void Start()
    {
        cooldownOverlay.fillAmount = 0f;
        blackOverlay.enabled = false;
    }

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            cooldownOverlay.fillAmount = cooldownTimer / cooldownTime;

            blackOverlay.enabled = true;
        }
        else
        {
            cooldownOverlay.fillAmount = 0f;
            blackOverlay.enabled = false;
        }

        // Beispiel: Wurf bei rechter Maustaste
        if (Input.GetMouseButtonDown(1) && cooldownTimer <= 0f)
        {
            ThrowBlattlaus();
            cooldownTimer = cooldownTime;
        }
    }

    void ThrowBlattlaus()
    {
        // Wurfcode hier
    }
}