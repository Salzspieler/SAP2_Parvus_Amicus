using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectableLogic : MonoBehaviour
{
    public int leavesCount;
    //public int croutonsCount;
    public GameObject[] leaves;
    public TMP_Text leavesText;
    //public GameObject[] croutons;

    private void Awake()
    {
        leaves = GameObject.FindGameObjectsWithTag("Leaf");
        //croutons = null;
    }

    public void CountLeaves()
    {
        leavesCount++;
        leavesText.text = leavesCount.ToString();
    }

    /*
    public void CountCroutons()
    {
        croutonsCount++;
    }
    */
}
