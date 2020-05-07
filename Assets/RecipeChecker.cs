using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecipeChecker : MonoBehaviour
{
    private XRSocketInteractor socket;
    private LoadFoodOntoPlate plateContents;

    public int carrotsOnPlate = 0;
    public int breadsOnPlate = 0;
    public int steaksOnPlate = 0;

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
            carrotsOnPlate = 0;
            steaksOnPlate = 0;
            breadsOnPlate = 0;

            plateContents = socket.selectTarget.GetComponentInChildren<LoadFoodOntoPlate>();
            foreach(GameObject carrot in plateContents.carrots)
            {
                if(carrot.activeInHierarchy == true)
                {
                    carrotsOnPlate += 1;
                }
            }

            foreach (GameObject steak in plateContents.steaks)
            {
                if (steak.activeInHierarchy == true)
                {
                    steaksOnPlate += 1;
                }
            }

            foreach (GameObject bread in plateContents.breads)
            {
                if (bread.activeInHierarchy == true)
                {
                    breadsOnPlate += 1;
                }
            }

            Debug.Log(carrotsOnPlate + steaksOnPlate + breadsOnPlate);
        }
    }
}
