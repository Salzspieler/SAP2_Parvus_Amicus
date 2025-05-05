using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Logic : MonoBehaviour
{
    public int itemsCollected = 0;
    public GameObject[] cherries;
    public TMP_Text itemsCollectedText;

    private void Awake()
    {
        cherries = GameObject.FindGameObjectsWithTag("Cherry");
    }

}
