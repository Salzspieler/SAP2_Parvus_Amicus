using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public int leavesCount;
    public int croutonsCount;
    public GameObject[] leaves;
    public TMP_Text leavesText;
    public GameObject[] croutons;
    public TMP_Text croutonsText;
    //public GameObject fifiCutScene;


    private void Awake()
    {
        leaves = GameObject.FindGameObjectsWithTag("Leaf");
        //croutons = null;
        if (croutons == null)
        {
            return;
        }
        else
        {
            croutons = GameObject.FindGameObjectsWithTag("Croutons");
        }
    }

    

    public void CountLeaves()
    {
        leavesCount++;
        leavesText.text = leavesCount.ToString();
    }


    public void CountCroutons()
    {
        croutonsCount++;
        croutonsText.text = croutonsCount.ToString();
    }
}
