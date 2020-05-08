using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparePlateToOrders : MonoBehaviour
{
    [SerializeField] RecipeChecker recipeChecker = null;

    [SerializeField] List<OrderTask> orderTasks = new List<OrderTask>();

    private List<OrderTask> completeOrders = new List<OrderTask>();
    private OrderTask _orderTask = null;

    public void CheckForOrderFullfilled(int cookedCarrotsOnPlate, int cookedSteaksOnPlate, int cookedBreadOnPlate)
    {
        foreach(OrderTask order in orderTasks)
        {
            float lifetimeOfThisOrder = order.orderTimer;
            if(order.isOrderActive == true)
            {
                if (cookedCarrotsOnPlate >= order.carrotsInOrder && cookedSteaksOnPlate >= order.steaksInOrder && cookedBreadOnPlate >= order.breadsInOrder)
                {
                    Debug.Log("plate had right food here");
                    completeOrders.Add(order);
                }
            } 
        }
        
        /*if (completeOrders.Count == 1)
        {
            _orderTask = completeOrders[0];
        }*/
        if (completeOrders.Count > 0)
        {
            _orderTask = completeOrders[0];
            float orderTimeCompare = completeOrders[0].orderTimer;
            for( int i = 1; i < completeOrders.Count; i++)
            {
                if (completeOrders[i].orderTimer > orderTimeCompare)
                {
                    _orderTask = completeOrders[i];
                    orderTimeCompare = _orderTask.orderTimer;
                }
            }
        }
        else
        {
            Debug.Log("no order at the moment");
        }

        if(_orderTask != null)
        {
            _orderTask.OrderSuccessfull();
            
        }
        else
        {
            Debug.Log("junk order");
        }

        _orderTask = null;
        completeOrders.Clear();

    }
}
