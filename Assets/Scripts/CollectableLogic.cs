using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectableLogic : MonoBehaviour
{
    public int leavesCount;
    public int croutonsCount;
    public GameObject[] leaves;
    public TMP_Text leavesText;
    public GameObject[] croutons;
    public TMP_Text croutonsText;

    private void Awake()
    {
        leaves = GameObject.FindGameObjectsWithTag("Leaf");
        //croutons = null;
        if(croutons == null)
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
