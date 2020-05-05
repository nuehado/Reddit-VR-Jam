using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecipeChecker : MonoBehaviour
{
    private XRSocketInteractor socket;
    private WhatsOnThePlate plateContents;
    
    void Start()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetAllFoodOnPlate()
    {
        if(socket.selectTarget.gameObject.name.Contains("Plate"))
        {
            plateContents = socket.selectTarget.GetComponent<WhatsOnThePlate>();
            foreach(string foodName in plateContents.foodOnPlate)
            {
                Debug.Log(foodName);
            }
            
        }
    }
}
