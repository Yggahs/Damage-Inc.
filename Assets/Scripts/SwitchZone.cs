using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchZone : MonoBehaviour {
    GameObject PlayerRef;
    Material currentMat;
    Material forestMat;
    Material labMat;
    Material officeMat;
    Material targetMat;
    private void Start()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("GameController");
        
        labMat = PlayerRef.transform.GetChild(7).GetComponent<BackgroundScript>().lab;
        forestMat = PlayerRef.transform.GetChild(7).GetComponent<BackgroundScript>().forest;
        officeMat = PlayerRef.transform.GetChild(7).GetComponent<BackgroundScript>().offices;

        targetMat = forestMat;

    }
    public void SwitchToForest()
    {
        if (targetMat != forestMat)
        {
            targetMat = forestMat;
            PlayerRef.transform.GetChild(7).GetComponent<BackgroundScript>().bgRend.material = targetMat;
        }
    }
    public void SwitchToLab()
    {
        if (targetMat != labMat)
        {
            targetMat = labMat;
            PlayerRef.transform.GetChild(7).GetComponent<BackgroundScript>().bgRend.material = targetMat;
        }
    }
    public void SwitchToOffices()
    {
        if (targetMat != labMat)
        {
            targetMat = officeMat;
            PlayerRef.transform.GetChild(7).GetComponent<BackgroundScript>().bgRend.material = targetMat;
        }
    }
}
