using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookableTracker : MonoBehaviour
{
    [SerializeField] private int amountCooked = 0;
    [SerializeField] private int cookedCompleteAmount = 100;
    [SerializeField] private int burnedCompleteAmount = 200;

    [SerializeField] ParticleSystem[] hitParticles;

    [SerializeField] Material cookedMaterial = null;
    [SerializeField] GameObject burnedFood = null;

    public bool isCooked = false;
    public string foodType = null;

    public bool mustBeBoiled = false;
    

    // Update is called once per frame
    void Update()
    {
        if (amountCooked > burnedCompleteAmount)
        {
            Instantiate(burnedFood, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(amountCooked > cookedCompleteAmount)
        {
            GetComponent<MeshRenderer>().material = cookedMaterial;
            isCooked = true;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.name.Contains("Flame") && mustBeBoiled == false)
        {
            ProcessCook();
        }
    }

    public void ProcessCook()
    {
        amountCooked += 1;
    }
}
