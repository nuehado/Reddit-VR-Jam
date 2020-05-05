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
    private float minFillHeight = Mathf.Epsilon;
    private float maxFillHeight = 0.5f;
    private float heightPerFillAmount = 0.0f;

    private void Start()
    {
        heightPerFillAmount = maxFillHeight / fillCompleteAmount;
    }

    private void Update()
    {
        if(amountFilled == 0)
        {
            liquid.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
        if(amountFilled > 0)
        {
            liquid.GetComponentInChildren<MeshRenderer>().enabled = true;
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
        }
        else if (amountFilled < 0)
        {
            returnAmountFilledInt = 0;
        }
        return returnAmountFilledInt;
    }
}
