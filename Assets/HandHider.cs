using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHider : MonoBehaviour
{
    [SerializeField] private MeshRenderer handSphere = null;
    private XRDirectInteractor interactor = null;
    
    private void Awake()
    {
        interactor = GetComponent<XRDirectInteractor>();

        interactor.onHoverEnter.AddListener(Hide);
        interactor.onHoverExit.AddListener(Show);
    }

    private void OnDestroy()
    {
        interactor.onHoverEnter.RemoveListener(Hide);
        interactor.onHoverExit.RemoveListener(Show);
    }

    private void Hide(XRBaseInteractable interactable)
    {
        handSphere.enabled = false;
    }

    private void Show(XRBaseInteractable interactable)
    {
        handSphere.enabled = true;
    }
}
