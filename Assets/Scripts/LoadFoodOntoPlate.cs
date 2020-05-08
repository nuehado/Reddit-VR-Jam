using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LoadFoodOntoPlate : MonoBehaviour
{
    private Collider plateLoadArea = null;
    public List<GameObject> carrots = new List<GameObject>();
    public List<GameObject> steaks = new List<GameObject>();
    public List<GameObject> breads = new List<GameObject>();

    [SerializeField] Transform destroyLocation;

    [SerializeField] MoveAndDestroy moveAndDestroy;

    // Start is called before the first frame update
    void Start()
    {
        plateLoadArea = GetComponent<Collider>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CookableTracker>() != null)
        {
            GameObject foodHittingPlate = other.gameObject;
            CookableTracker foodCookTracker = foodHittingPlate.GetComponent<CookableTracker>();

            if(foodCookTracker.isCooked == true)
            {
                string foodHittingType = foodCookTracker.foodType;
                if (foodHittingType != null)
                {
                    TransferToPlate(foodHittingPlate, foodCookTracker, foodHittingType);
                }
            }
        }
    }

    private void TransferToPlate(GameObject foodObject, CookableTracker foodCookTracker, string foodType)
    {
        if(foodType == "Carrot")
        {
            for(int i = 0; i < carrots.Count; i++)
            {
                if (carrots[i].activeInHierarchy == false)
                {
                    carrots[i].SetActive(true);
                    moveAndDestroy.CustomDestroy(foodObject);
                    return;
                }
            }

        }
        else if (foodType == "Steak")
        {
            for (int i = 0; i < steaks.Count; i++)
            {
                if (steaks[i].activeInHierarchy == false)
                {
                    steaks[i].SetActive(true);
                    moveAndDestroy.CustomDestroy(foodObject);
                    return;
                }
            }

        }
        else if (foodType == "Bread")
        {
            for (int i = 0; i < breads.Count; i++)
            {
                if (breads[i].activeInHierarchy == false)
                {
                    breads[i].SetActive(true);
                    moveAndDestroy.CustomDestroy(foodObject);
                    return;
                }
            }
        }
        else
        {
            return;
        }
    }

    public IEnumerator ClearFoodOffPlate(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        foreach(GameObject carrot in carrots)
        {
            carrot.SetActive(false);
        }

        foreach (GameObject steak in steaks)
        {
            steak.SetActive(false);
        }

        foreach (GameObject bread in breads)
        {
            bread.SetActive(false);
        }
    }
}
