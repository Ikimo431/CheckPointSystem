using System;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    [SerializeField] private int checkPointNumber;
    [SerializeField] private Transform spawnLocation;
    [SerializeField] private Quaternion spawnRotation;

    
    private void OnTriggerEnter(Collider other)
    {
        LapCounter lapCounter = other.GetComponent<LapCounter>();
        if (other.tag == "Player" && lapCounter != null)
        {
            //if the car's current checkpoint is not this, or the previous checkpoint, return to previous
            if (lapCounter.GetCurrCheckPoint().GetNumber() != checkPointNumber - 1 
                && lapCounter.GetCurrCheckPoint().GetNumber() != checkPointNumber)
            {
                lapCounter.ReturnToPrevCheckPoint();
            }
            else
            {
                lapCounter.SetCurrCheckPoint(this);
            }
        }
    }


    //-----Getters and setters------
    public int getCheckPointNumber()
    {
        return checkPointNumber;
    }
    
    public int GetNumber()
    {
        return checkPointNumber;
    }

    public Vector3 getSpawnLocation()
    {
        return spawnLocation.position;
    }

    public Quaternion getSpawnRotation()
    {
        return spawnRotation;
    }

   
}
