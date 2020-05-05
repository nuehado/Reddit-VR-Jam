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

    void Update()
    {
        AdjustFillLevel();
    }

    private void AdjustFillLevel()
    {
        float updatedFillHeight = heightPerFillAmount * amountFilled;

        ClampFillHeights(updatedFillHeight);

        Vector3 fillLevelPosition = new Vector3(liquid.transform.localPosition.x, updatedFillHeight, liquid.transform.localPosition.z);

        liquid.transform.localPosition = fillLevelPosition;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.name.Contains("Water"))
        {
            ProcessFill(1);
        }
    }

    private void ProcessFill(int fillChangeAmount)
    {
        amountFilled += fillChangeAmount;
    }

    private float ClampFillHeights(float newHeight)
    {
        float returnHeight = 0.0f;
        if (newHeight > maxFillHeight)
        {
            returnHeight = maxFillHeight;
        }
        else if (newHeight < minFillHeight)
        {
            returnHeight = minFillHeight;
        }

        return returnHeight;
    }
}
