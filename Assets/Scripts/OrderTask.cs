using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrderTask : MonoBehaviour
{
    public int carrotsInOrder = 0;
    public int steaksInOrder = 0;
    public int breadsInOrder = 0;

    public bool isOrderActive = false;
    public float timeToCook = 60f;
    public float orderTimer = 0f;
    [SerializeField] GameObject failedCanvasIcon;
    [SerializeField] TextMeshProUGUI secondsLeft;

    private void OnEnable()
    {
        //NewOrder();
    }

    // Update is called once per frame
    void Update()
    {
        if (isOrderActive == true)
        {
            orderTimer += Time.deltaTime;
            secondsLeft.text = Mathf.RoundToInt((timeToCook - orderTimer)).ToString();
            if (orderTimer > timeToCook)
            {
                Debug.Log("orderfailed"); //do some stuff
                isOrderActive = false;
                failedCanvasIcon.SetActive(true);
            }
        }
        else
        {
            secondsLeft.text = "";
        }
    }

    public void NewOrder(float timeToCompleteOrder)
    {
        isOrderActive = true;
        orderTimer = 0f;
        carrotsInOrder = Random.Range(0, 4);
        steaksInOrder = Random.Range(0, 4);
        breadsInOrder = Random.Range(0, 4);
        if (carrotsInOrder + steaksInOrder + breadsInOrder == 0)
        {
            steaksInOrder = 1;
        }

        timeToCook = timeToCompleteOrder;
    }

    public void OrderSuccessfull()
    {
        Debug.Log("order complete!");
        isOrderActive = false;
        orderTimer = 0f;

        //NewOrder(timeToCook);
    }
}
