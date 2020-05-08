using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketActivator : MonoBehaviour
{
    private XRSocketInteractor socketInteractor = null;

    [SerializeField] private GameObject activatorTool;

    void Start()
    {
        socketInteractor = GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == activatorTool.gameObject)
        {
            socketInteractor.socketActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == activatorTool.gameObject)
        {
            socketInteractor.socketActive = false;
        }
    }
}
