using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlateContentReporter : MonoBehaviour
{
    private XRSocketInteractor socket = null;
    private WhatsOnThePlate plate;
    private CookableTracker foodInSocket;
    // Start is called before the first frame update
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
        plate = GetComponentInParent<WhatsOnThePlate>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReportFoodInSocket()
    {
        foodInSocket = socket.selectTarget.GetComponent<CookableTracker>();
        if (foodInSocket.isCooked == true)
        {
            plate.foodOnPlate.Add(foodInSocket.foodType);
        }
    }

    public void ReportFoodLeavesSocket()
    {
        if(foodInSocket.isCooked == true)
        {
            plate.foodOnPlate.Remove(foodInSocket.foodType);
        }
        
    }
}
