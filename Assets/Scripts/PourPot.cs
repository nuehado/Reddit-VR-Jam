using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PourPot : MonoBehaviour
{
    [SerializeField] private float pourSpeed = 0.0001f;
    [SerializeField] private WaterFillDetector waterFillDetector;
    [SerializeField] ParticleSystem waterParticles;
    private Vector3 potCenterPosition = new Vector3(0f, 0f, 0f);
    [SerializeField] GameObject potCenter;
    [SerializeField] private StewMaker stewMaker;

    private float pourTimer = 0.0f;

    private bool isPouring = false;

    private void Start()
    {

    }

    void Update()
    {
        if(waterFillDetector.isEmpty == false)
        {
            CheckForPourAngle();
        }
        else if(waterFillDetector.isEmpty == true)
            {
                StopPouring();
            }

        if (isPouring == true)
        {
            pourTimer += Time.deltaTime;
        }

        if(pourTimer >= pourSpeed)
        {
            waterFillDetector.ProcessFillAmount(-1);
            waterFillDetector.isFilled = false;
            pourTimer = 0.0f;
        }

        
    }

    private void CheckForPourAngle()
    {
        Vector3 localUp = transform.up;
        float rotationAngle = Vector3.Angle(Vector3.up, localUp);
        if (rotationAngle > 90f)
        {
            isPouring = true;
            SetPourDirection(rotationAngle);
            waterParticles.Play();
            foreach(GameObject potCarrot in stewMaker.cookingCarrots)
            {
                if (potCarrot.GetComponent<BoilCompleteTracker>().isBoiled)
                {
                    Instantiate(potCarrot.GetComponent<BoilCompleteTracker>().cookedCarrotPiece, potCarrot.transform.position, Quaternion.identity);
                    potCarrot.GetComponent<BoilCompleteTracker>().isBoiled = false;
                }
            }
        }
    }

    private void StopPouring()
    {
        isPouring = false;
        potCenterPosition = potCenter.transform.position;
        waterParticles.transform.position = potCenterPosition;
        waterParticles.Stop();
    }

    private void SetPourDirection(float rotationAngle)
    {
        potCenterPosition = potCenter.transform.position;
        if (rotationAngle < 120f)
        {
            Vector3 newParticlePosition = potCenterPosition + new Vector3(0f, -0.08f, 0f);
            waterParticles.transform.position = newParticlePosition;
        }

        else
        {
            Vector3 newParticlePosition = potCenterPosition + new Vector3(0f, -0.12f, 0f);
            waterParticles.transform.position = newParticlePosition;
        }
    }
}
