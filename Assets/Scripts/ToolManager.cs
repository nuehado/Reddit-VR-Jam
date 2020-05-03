using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    private WatchToolInventory watchToolInventory;
    private void Awake()
    {
        watchToolInventory = new WatchToolInventory();
    }
}
