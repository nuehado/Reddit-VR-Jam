﻿using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OffsetGrab : XRGrabInteractable
{
    private Vector3 interactorPosition = Vector3.zero;
    private Quaternion interactorRotation = Quaternion.identity;


    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (interactor.name.Contains("Hand"))
        {
            base.OnSelectEnter(interactor);
            StoreInteractor(interactor);
            MatchAttachmentPoints(interactor);
        }
        
        else
        {
            base.OnSelectEnter(interactor);
        }
    }

    private void StoreInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = interactor.attachTransform.localPosition;
        interactorRotation = interactor.attachTransform.localRotation;
    }

    private void MatchAttachmentPoints(XRBaseInteractor interactor)
    {
        bool hasAttach = attachTransform != null;
        interactor.attachTransform.position = hasAttach ? attachTransform.position : transform.position;
        interactor.attachTransform.rotation = hasAttach ? attachTransform.rotation : transform.rotation;
    }
    protected override void OnSelectExit(XRBaseInteractor interactor)
    {
        if (interactor.name.Contains("Hand"))
        {
            base.OnSelectExit(interactor);
            ResetAttachmentPoint(interactor);
            ClearInteractor(interactor);
        }

        else
        {
            base.OnSelectEnter(interactor);
        }
        
    }
    private void ResetAttachmentPoint(XRBaseInteractor interactor)
    {
        interactor.attachTransform.localPosition = interactorPosition;
        interactor.attachTransform.localRotation = interactorRotation;
    }

    private void ClearInteractor(XRBaseInteractor interactor)
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }

    
}
