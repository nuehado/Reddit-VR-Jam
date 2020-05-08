using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadCutter : MonoBehaviour
{
    [SerializeField] GameObject breadSlice = null;
    private float cutWaitTime = 0.25f;
    private bool isCuttable = true;

    void Start()
    {
        StartCoroutine(DelayCutting());
    }

    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Knife") && isCuttable == true)
        {
            Cut();
            isCuttable = false;
            StartCoroutine(DelayCutting());
        }
    }

    private void Cut()
    {
        Instantiate(breadSlice, transform);

    }

    private IEnumerator DelayCutting()
    {
        yield return new WaitForSeconds(cutWaitTime);

        isCuttable = true;
    }
}
