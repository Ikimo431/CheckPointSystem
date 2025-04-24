using System;
using UnityEngine;

public class StartLineController : MonoBehaviour
{
    [SerializeField] private int lastCheckpoint = 0;
    private void OnTriggerEnter(Collider other)
    {
        LapCounter lapCounter = other.GetComponent<LapCounter>();
        if (other.tag == "Player" && lapCounter != null)
        {
            if (lapCounter.GetCurrCheckPoint().GetNumber() == lastCheckpoint || lapCounter.getCurrentLap()==0)
            {
                lapCounter.IncrLap();
                lapCounter.SetCurrCheckPoint(GetComponent<CheckPointController>()); 
            }
           
        }
    }
}
