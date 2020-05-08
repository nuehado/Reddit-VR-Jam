using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutToPieces : MonoBehaviour
{
    [SerializeField] List<GameObject> afterCutPieces = new List<GameObject>();
    private float cutWaitTime = 0.25f;
    private bool isCuttable = false;

    private void OnEnable()
    {
        StartCoroutine(DelayCutting());
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains("Knife") && isCuttable == true)
        {
            Cut();
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Knife") && isCuttable == true)
        {
            Cut();
        }
    }*/

    private void Cut()
    {
        foreach (GameObject piece in afterCutPieces)
        {
            piece.transform.position = transform.position;
            piece.transform.localRotation = transform.localRotation;
            piece.SetActive(true);
        }

        this.gameObject.SetActive(false);

    }

    private IEnumerator DelayCutting()
    {
        yield return new WaitForSeconds(cutWaitTime);

        isCuttable = true;
    }
}
