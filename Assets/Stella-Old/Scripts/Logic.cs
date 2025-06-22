using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Logic : MonoBehaviour
{
    public int aphidCollect = 0;
    public GameObject aphid;

    private void Awake()
    {
        aphid = GameObject.FindGameObjectWithTag("Aphid");
    }

}
