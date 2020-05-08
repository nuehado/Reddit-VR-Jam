using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RecipeChecker : MonoBehaviour
{
    private XRSocketInteractor socket;
    private LoadFoodOntoPlate loadFoodOntoPlate;
    [SerializeField] ComparePlateToOrders comparePlateToOrders;

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

            loadFoodOntoPlate = socket.selectTarget.GetComponentInChildren<LoadFoodOntoPlate>();
            foreach(GameObject carrot in loadFoodOntoPlate.carrots)
            {
                if(carrot.activeInHierarchy == true)
                {
                    carrotsOnPlate += 1;
                }
            }

            foreach (GameObject steak in loadFoodOntoPlate.steaks)
            {
                if (steak.activeInHierarchy == true)
                {
                    steaksOnPlate += 1;
                }
            }

            foreach (GameObject bread in loadFoodOntoPlate.breads)
            {
                if (bread.activeInHierarchy == true)
                {
                    breadsOnPlate += 1;
                }
            }

            comparePlateToOrders.CheckForOrderFullfilled(carrotsOnPlate, steaksOnPlate, breadsOnPlate);
            loadFoodOntoPlate.StartCoroutine("ClearFoodOffPlate", 1f);
        }
    }
}
