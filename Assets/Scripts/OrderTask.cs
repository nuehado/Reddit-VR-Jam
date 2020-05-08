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
    public bool isLost = false;
    [SerializeField] OrderPlacer orderPlacer;
    [SerializeField] LevelManager levelManager;
    [SerializeField] UpdateOrderBoard updateOrderBoard;

    private int completedOrders = 0;
    [SerializeField] private int ordersToComplete = 3;
    [SerializeField] GameObject completeIcon;
    public bool isComplete = false;


    // Update is called once per frame
    void Update()
    {
        if (isOrderActive == true)
        {
            orderTimer += Time.deltaTime;
            secondsLeft.text = Mathf.RoundToInt((timeToCook - orderTimer)).ToString();
            if (orderTimer > timeToCook)
            {
                Debug.Log("orderfailed"); //todo some stuff
                isOrderActive = false;
                failedCanvasIcon.SetActive(true);
                isLost = true;
                levelManager.CheckIfAllOrdersFailed();
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
        completedOrders += 1;
        if(completedOrders >= ordersToComplete)
        {
            isOrderActive = false;
            updateOrderBoard.ResetFoodIcons();
            completeIcon.SetActive(true);
            isComplete = true;
            levelManager.CheckIfLevelWon();
        }
        else
        {
            if (isLost == false)
            {
                StartCoroutine(StartNextOrder());
            }
        }
        
    }

    private IEnumerator StartNextOrder()
    {
        yield return new WaitForSeconds(orderPlacer.selectedTimeBetweenf3orders);

        NewOrder(orderPlacer.selectedTimeToCompleteOrder);

    }

    public void ResetOrderCompletely()
    {
        isOrderActive = false;
        isComplete = false;
        failedCanvasIcon.SetActive(false);
        completeIcon.SetActive(false);
        orderTimer = 0f;
        isLost = false;
        carrotsInOrder = 0;
        steaksInOrder = 0;
        breadsInOrder = 0;
        updateOrderBoard.ResetFoodIcons();
    }
}
