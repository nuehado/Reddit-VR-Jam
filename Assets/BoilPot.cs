using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilPot : MonoBehaviour
{
    public bool isHeated = false;
    [SerializeField] private int amountCooked = 0;
    [SerializeField] private int cookedCompleteAmount = 100;
    [SerializeField] StewMaker stewMaker;
    [SerializeField] WaterFillDetector waterFillDetector;
    [SerializeField] ParticleSystem[] hitParticles;
    [SerializeField] private int coolingTime = 10;
    private float coolTimer = 0f;

    void Update()
    {
        if (amountCooked > cookedCompleteAmount)
        {
            isHeated = true;
            foreach(GameObject carrot in stewMaker.cookingCarrots)
            {
                if(carrot.activeInHierarchy == true)
                {
                    carrot.GetComponent<MeshRenderer>().material = stewMaker.cookedCarrotMaterial;
                    carrot.GetComponent<BoilCompleteTracker>().isBoiled = true;
                }
            }

            coolTimer += Time.deltaTime;
            if(coolTimer >= coolingTime)
            {
                amountCooked = 0;
                coolTimer = 0.0f;
            }
        }

        else
        {
            isHeated = false;
        }

    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.name.Contains("Flame") && waterFillDetector.isFilled == true)
        {
            ProcessCook();
        }
    }

    public void ProcessCook()
    {
        amountCooked += 1;
    }

    public void ResetAmountCooked()
    {
        amountCooked = 0;
    }
}

