using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] MoveAndDestroy moveAndDestroy;
    [SerializeField] List<OrderTask> orderTasks = new List<OrderTask>();
    [SerializeField] GameObject winLevelPanel;
    [SerializeField] GameObject loseLevelPanel;
    [SerializeField] OrderPlacer orderPlacer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void CheckIfAllOrdersFailed()
    {
        foreach(OrderTask orderTask in orderTasks)
        {
            if(orderTask.isLost == false)
            {
                return;
            }
        }
        Debug.Log("you lose this level"); //do some stuff
        foreach(OrderTask orderTask in orderTasks)
        {
            orderTask.ResetOrderCompletely();
            loseLevelPanel.SetActive(true);
            orderPlacer.isLevelActive = false;
        }
    }
    
    public void CheckIfLevelWon()
    {
        foreach(OrderTask orderTask in orderTasks)
        {
            if (orderTask.isComplete == false)
            {
                return;
            }
            else if (orderTask.isLost == true)
            {
                return;
            }
        }

        Debug.Log("the level is won!"); //todo some stuff
        foreach (OrderTask orderTask in orderTasks)
        {
            orderTask.ResetOrderCompletely();
            winLevelPanel.SetActive(true);
            orderPlacer.isLevelActive = false;
        }
    }


    public void GetAllFoodAndDelete()
    {
        // todo test
        foreach(Food food in FindObjectsOfType<Food>())
        {
            moveAndDestroy.CustomDestroy(food.gameObject);
        }
    }
}
