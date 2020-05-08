using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabberActivator : MonoBehaviour
{
    public AxisHandler1D primaryAxis1DHandler = null;
    [SerializeField] XRSocketInteractor socket;

    public void OnEnable()
    {
        primaryAxis1DHandler.OnValueChange += ActivateGrabber;
    }

    public void OnDisable()
    {
        primaryAxis1DHandler.OnValueChange -= ActivateGrabber;
        socket.socketActive = false;
    }

    private void ActivateGrabber(XRController controller, float value)
    {
        if(value >= 0.5f)
        {
            socket.socketActive = true;
        }
        else
        {
            socket.socketActive = false;
        }
    }
}
