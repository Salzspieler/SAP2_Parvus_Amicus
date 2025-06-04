using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectableLogic : MonoBehaviour
{
    public int leavesCount;
    //public int croutonsCount;
    public GameObject[] leaves;
    //public GameObject[] croutons;

    private void Awake()
    {
        leaves = GameObject.FindGameObjectsWithTag("Leaf");
        //croutons = null;
    }

    public void CountLeaves()
    {
        leavesCount++;
    }

    /*
    public void CountCroutons()
    {
        croutonsCount++;
    }
    */
}
