using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Test_Interactable_ColorChange : MonoBehaviour
{
    public Material greyMaterial = null;
    public Material yellowMaterial = null;

    private MeshRenderer[] meshRenderers = null;
    private XRGrabInteractable grabInteractable = null;

    [SerializeField] private bool isEnabled = false;

    private void Awake()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.onActivate.AddListener(SetYellow);
        grabInteractable.onDeactivate.AddListener(SetGrey);
    }

    private void OnDestroy()
    {
        grabInteractable.onActivate.RemoveListener(SetYellow);
        grabInteractable.onDeactivate.RemoveListener(SetGrey);
    }

    private void SetGrey(XRBaseInteractor interactor)
    {
        if (isEnabled)
        {
            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                meshRenderer.material = greyMaterial;
            }
        }
    }

    private void SetYellow(XRBaseInteractor interactor)
    {
        if (isEnabled)
        {
            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                meshRenderer.material = yellowMaterial;
            }
        }   
    }
}
