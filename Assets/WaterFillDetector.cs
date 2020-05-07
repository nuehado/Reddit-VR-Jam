using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFillDetector : MonoBehaviour
{
    public int amountFilled = 0;
    [SerializeField] private int fillCompleteAmount = 100;

    [SerializeField] ParticleSystem[] hitParticles;

    [SerializeField] GameObject liquid;

    public bool isFilled = false;
    public bool isEmpty = false;
    private float minFillHeight = Mathf.Epsilon;
    private float maxFillHeight = 0.5f;
    private float heightPerFillAmount = 0.0f;

    [SerializeField] MeshRenderer waterRenderer;
    private Material originalWaterMaterial;
    [SerializeField] private Material filledWaterMaterial;
    [SerializeField] BoilPot boilPot;
    [SerializeField] Material hotWaterMaterial;

    private void Start()
    {
        heightPerFillAmount = maxFillHeight / fillCompleteAmount;
        originalWaterMaterial = waterRenderer.material;
    }

    private void Update()
    {
        if(amountFilled == 0)
        {
            liquid.GetComponentInChildren<MeshRenderer>().enabled = false;
            isEmpty = true;
        }
        else if(amountFilled > 0)
        {
            liquid.GetComponentInChildren<MeshRenderer>().enabled = true;
            isEmpty = false;
        }
        if(amountFilled >= fillCompleteAmount)
        {
            isFilled = true;
        }

        if (isFilled == true)
        {
            if(boilPot.isHeated == true)
            {
                waterRenderer.material = hotWaterMaterial;
            }
            else
            {
                waterRenderer.material = filledWaterMaterial;
            }
        }
        else
        {
            waterRenderer.material = originalWaterMaterial;
        }
    }

    private void AdjustFillLevel()
    {
        float updatedFillHeight = heightPerFillAmount * amountFilled;

        Vector3 fillLevelPosition = new Vector3(liquid.transform.localPosition.x, updatedFillHeight, liquid.transform.localPosition.z);

        liquid.transform.localPosition = fillLevelPosition;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.name.Contains("Water"))
        {
            Debug.Log("hit");
            ProcessFillAmount(1);
        }
    }

    public void ProcessFillAmount(int fillChangeAmount)
    {
        amountFilled += fillChangeAmount;

        amountFilled = ClampAmountFilledInt();

        AdjustFillLevel();
    }

    private int ClampAmountFilledInt()
    {
        int returnAmountFilledInt = amountFilled;
        if (amountFilled > fillCompleteAmount)
        {
            returnAmountFilledInt = fillCompleteAmount;
            isFilled = true;
        }
        else if (amountFilled < 0)
        {
            returnAmountFilledInt = 0;
        }
        return returnAmountFilledInt;
    }
}
