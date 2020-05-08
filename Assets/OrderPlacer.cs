using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPlacer : MonoBehaviour
{
    [SerializeField] List<OrderTask> orderTasks = new List<OrderTask>();

    [SerializeField] private float easyTimeBetweenF3orders = 120f;
    [SerializeField] private float easyTimeToCompleteOrder = 180f;
    [SerializeField] private float mediumTimeBetweenF3orders = 60f;
    [SerializeField] private float mediumTimeToCompleteOrder = 120f;
    [SerializeField] private float hardTimeBetweenF3orders = 30f;
    [SerializeField] private float hardTimeToCompleteOrder = 90f;

    public float selectedTimeBetweenf3orders;
    public float selectedTimeToCompleteOrder;

    private float f3OrdersTimer = 0f;
    private bool isLevelStarting = false;
    public bool isLevelActive = false;

    [SerializeField] GameObject winLevelPanel;
    [SerializeField] GameObject loseLevelPanel;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isLevelStarting == true)
        {
            loseLevelPanel.SetActive(false);
            winLevelPanel.SetActive(false);
            f3OrdersTimer += Time.deltaTime;
            if (f3OrdersTimer >= 2 * selectedTimeBetweenf3orders && orderTasks[2].isOrderActive == false)
            {
                orderTasks[2].NewOrder(selectedTimeToCompleteOrder);
                isLevelStarting = false;
                f3OrdersTimer = 0f;
            }
            else if (f3OrdersTimer >= selectedTimeBetweenf3orders && orderTasks[1].isOrderActive == false)
            {
                orderTasks[1].NewOrder(selectedTimeToCompleteOrder);
            }
        }
    }

    public void StartPlacingOrders(int difficultyIndex)
    {
        if(isLevelActive == false)
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

            if (orderTasks[0].isOrderActive == false)
            {
                orderTasks[0].NewOrder(selectedTimeToCompleteOrder);
                isLevelStarting = true;
                isLevelActive = true;
            }
        }
    }
}
