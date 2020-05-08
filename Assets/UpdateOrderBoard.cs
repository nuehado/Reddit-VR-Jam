using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateOrderBoard : MonoBehaviour
{
    [SerializeField] List<GameObject> carrotIcons = new List<GameObject>();
    [SerializeField] List<GameObject> steakIcons = new List<GameObject>();
    [SerializeField] List<GameObject> breadIcons = new List<GameObject>();

    [SerializeField] OrderTask orderTask;

    void Update()
    {
        UpdateOrderIconsActive();
    }

    public void UpdateOrderIconsActive()
    {
        int carrotsToDisplay = orderTask.carrotsInOrder;
        int steaksToDisplay = orderTask.steaksInOrder;
        int breadsToDisplay = orderTask.breadsInOrder;

        for (int i = 1; i <= carrotIcons.Count; i++)
        {
            if (i <= carrotsToDisplay)
            {
                carrotIcons[i - 1].SetActive(true);
            }
        }

        for (int i = 1; i <= breadIcons.Count; i++)
        {
            if (i <= breadsToDisplay)
            {
                breadIcons[i - 1].SetActive(true);
            }
        }

        for (int i = 1; i <= steakIcons.Count; i++)
        {
            if (i <= steaksToDisplay)
            {
                steakIcons[i - 1].SetActive(true);
            }
        }
    }
}
