using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StewMaker : MonoBehaviour
{
    private WaterFillDetector waterFillDetector = null;

    public List<GameObject> cookingCarrots = new List<GameObject>();

    public Material cookedCarrotMaterial;
    private Material rawCarrotMaterial;

    void Start()
    {
        waterFillDetector = GetComponent<WaterFillDetector>();
        rawCarrotMaterial = cookingCarrots[0].gameObject.GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        if(waterFillDetector.isFilled == false)
        {
            foreach(GameObject carrot in cookingCarrots)
            {
                carrot.GetComponent<MeshRenderer>().material = rawCarrotMaterial;
                carrot.SetActive(false);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(waterFillDetector.isFilled == false)
        {
            return;
        }

        if (collision.gameObject.GetComponent<CookableTracker>() != null)
        {
            GameObject foodPutIntoPot = collision.gameObject;
            CookableTracker foodCookTracker = foodPutIntoPot.GetComponent<CookableTracker>();
            if(foodCookTracker.foodType != "Carrot" && foodCookTracker.isCooked == false)
            {
                return;
            }

            for (int i = 0; i < cookingCarrots.Count; i++)
            {
                if (cookingCarrots[i].activeInHierarchy == false)
                {
                    cookingCarrots[i].SetActive(true);
                    
                    
                    Destroy(foodPutIntoPot); //todo change this and all destroy and instantiates into a "destroy" object pooling implementation
                    return;
                }
            }

        }
    }
}
