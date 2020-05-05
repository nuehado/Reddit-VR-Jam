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
    private Material rawMaterial = null;
    [SerializeField] GameObject burnedFood = null;

    [SerializeField] private bool isCooked = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rawMaterial = GetComponent<Material>();
    }

    // Update is called once per frame
    void Update()
    {
        if (amountCooked > burnedCompleteAmount)
        {
            Debug.Log("ya burned it");
            Instantiate(burnedFood, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(amountCooked > cookedCompleteAmount)
        {
            Debug.Log("ya cooked it!");
            GetComponent<MeshRenderer>().material = cookedMaterial;
            isCooked = true;
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("particles hit");
        if (other.gameObject.name.Contains("Flame"))
        {
            ProcessCook();
        }
    }

    private void ProcessCook()
    {
        amountCooked += 1;
    }
}
