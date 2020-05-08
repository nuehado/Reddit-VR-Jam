using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPlacer : MonoBehaviour
{
    [SerializeField] List<OrderTask> orderTasks = new List<OrderTask>();

    [SerializeField] private float easyTimeBetweenF3orders = 120f;
    [SerializeField] private float mediumTimeBetweenF3orders = 60f;
    [SerializeField] private float hardTimeBetweenF3orders = 30f;

    [SerializeField] private float easyTimeToCompleteOrder = 180f;
    [SerializeField] private float mediumTimeToCompleteOrder = 120f;
    [SerializeField] private float hardTimeToCompleteOrder = 90f;

    private float selectedTimeBetweenf3orders;
    private float selectedTimeToCompleteOrder;

    private float f3OrdersTimer = 0f;
    private bool levelStarting = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levelStarting == true)
        {
            
            f3OrdersTimer += Time.deltaTime;
            if(f3OrdersTimer >= 2 * selectedTimeBetweenf3orders)
            {
                orderTasks[2].NewOrder(selectedTimeToCompleteOrder);
            }
            else if (f3OrdersTimer >= selectedTimeBetweenf3orders)
            {
                orderTasks[1].NewOrder(selectedTimeToCompleteOrder);
                levelStarting = false;
                f3OrdersTimer = 0f;
            }
        }
    }

    public void StartPlacingOrders(int difficultyIndex)
    {
        if (difficultyIndex == 1)
        {
            selectedTimeBetweenf3orders = easyTimeBetweenF3orders;
            selectedTimeToCompleteOrder = easyTimeToCompleteOrder;
        }
        else if (difficultyIndex == 2)
        {
            selectedTimeBetweenf3orders = mediumTimeBetweenF3orders;
            selectedTimeToCompleteOrder = mediumTimeToCompleteOrder;
        }
        else if (difficultyIndex == 3)
        {
            selectedTimeBetweenf3orders = hardTimeBetweenF3orders;
            selectedTimeToCompleteOrder = hardTimeToCompleteOrder;
        }

        orderTasks[0].NewOrder(selectedTimeToCompleteOrder);
        levelStarting = true;

        
    }

    public void QueueNewOrder()
    {

    }
}
