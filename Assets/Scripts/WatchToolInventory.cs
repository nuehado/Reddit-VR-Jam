using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchToolInventory
{
    private List<WatchTool> toolList;

    public WatchToolInventory()
    {
        toolList = new List<WatchTool>();
        Debug.Log("Tool Inventory");

        AddTool(new WatchTool { toolType = WatchTool.ToolType.Knife });
    }

    public void AddTool(WatchTool watchTool)
    {
        toolList.Add(watchTool);
    }
}
