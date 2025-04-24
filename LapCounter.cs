using System;
using TMPro;
using UnityEngine;

public class LapCounter : MonoBehaviour
{ 
    //laps
    [SerializeField] private int totalLaps = 3;
    private int lapCount = 0;
    //checkpoints
    [SerializeField, Tooltip("This should be the start line")]private CheckPointController startingCheckPoint;
    private CheckPointController currCheckPoint;
    [Range(1, 2), SerializeField] private int playerNumber = 1;
    private String playerResetString;
    //ui
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI lapCountText;
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lapCount = 0;
        winText.text = "";
        lapCountText.text = "Lap " + lapCount + "/" + totalLaps;
        currCheckPoint = startingCheckPoint;
        playerResetString = "Reset" + playerNumber;
    }

    public void IncrLap()
    {
        lapCount++;
        
        if (lapCount > totalLaps)
        {
            winText.text = "You Win!";
        }
        else
        {
            lapCountText.text = "Lap " + lapCount + "/" + totalLaps;
        }
        
    }

    private void Update()
    {
        if (Input.GetButtonDown(playerResetString))
        {
            ReturnToPrevCheckPoint();
        }
    }

    public void ReturnToPrevCheckPoint()
    {
        transform.position = currCheckPoint.getSpawnLocation();
        transform.rotation = currCheckPoint.getSpawnRotation();
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
    
    
    //----------------Getters and setters-------------------- 
    public void SetCurrCheckPoint(CheckPointController currCheckPoint)
    {
        this.currCheckPoint = currCheckPoint;
    }
    public CheckPointController GetCurrCheckPoint()
    {
        return currCheckPoint;
    }
    public int getCurrentLap()
    {
        return lapCount;
    }
    
   
    
}
