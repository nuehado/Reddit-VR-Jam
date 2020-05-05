using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabberDisabler : MonoBehaviour
{
    [SerializeField] XRSocketInteractor socket;
    // Start is called before the first frame update
    public void DisableGrabberTool()
    {
        socket.socketActive = false;
        this.gameObject.SetActive(false);
    }
}
