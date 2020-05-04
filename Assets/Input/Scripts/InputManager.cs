using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InputManager : MonoBehaviour
{
    public List<ButtonHandler> allButtonHandlers = new List<ButtonHandler>();
    public List<AxisHandler1D> allAxisHandlers1D = new List<AxisHandler1D>();
    public List<AxisHandler2D> allAxisHandlers2D = new List<AxisHandler2D>();

    private XRController controller = null;
    
    private void Awake()
    {
        controller = GetComponent<XRController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleButtonEvents();
        HandleAxisEvents1D();
        HandleAxisEvents2D();
    }

    private void HandleButtonEvents()
    {
        foreach(ButtonHandler handler in allButtonHandlers)
        {
            handler.HandleState(controller);
        }
    }

    private void HandleAxisEvents1D()
    {
        foreach (AxisHandler1D handler in allAxisHandlers1D)
        {
            handler.HandleState(controller);
        }
    }

    private void HandleAxisEvents2D()
    {
        foreach (AxisHandler2D handler in allAxisHandlers2D)
        {
            handler.HandleState(controller);
        }
    }
}

