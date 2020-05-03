using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class WristButton : XRBaseInteractable
{
    public UnityEvent OnPress = null;
    private bool previousPress = false;
    private float yMin = 0.0f;
    private float yMax = 0.0f;
    private XRBaseInteractor hoverInteractor = null;
    private float previousHandHeight = 0.0f;

    protected override void Awake()
    {
        base.Awake();

        onHoverEnter.AddListener(StartPressButton);
        onHoverExit.AddListener(EndPressButton);
    }

    private void Start()
    {
        SetMinMix();
    }

    private void SetMinMix()
    {
        Collider collider = GetComponent<Collider>();
        yMin = transform.localPosition.y - (collider.bounds.size.y * 0.5f);
        Debug.Log(yMin);
        yMax = transform.localPosition.y;
        Debug.Log(yMax);
    }

    private void OnDestroy()
    {
        onHoverEnter.RemoveListener(StartPressButton);
        onHoverExit.RemoveListener(EndPressButton);
    }

    private void StartPressButton(XRBaseInteractor interactor)
    {
        hoverInteractor = interactor;
        previousHandHeight = GetLocalYPosition(hoverInteractor.transform.position);
        Debug.Log("touch detected");
    }

    private void EndPressButton(XRBaseInteractor interactor)
    {
        hoverInteractor = null;
        previousHandHeight = 0.0f;

        previousPress = false;
        SetYPosition(yMax);
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (hoverInteractor)
        {
            float newHandheight = GetLocalYPosition(hoverInteractor.transform.position);
            float handDifference = previousHandHeight - newHandheight;
            previousHandHeight = newHandheight;

            float newPosition = transform.localPosition.y - handDifference;
            SetYPosition(newPosition);

            CheckPress();
        }
    }

    private float GetLocalYPosition(Vector3 position)
    {
        Vector3 localposition = transform.root.InverseTransformPoint(position);
        return localposition.y;
    }

    private void SetYPosition(float yPosition)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Mathf.Clamp(yPosition, yMin, yMax);
        transform.localPosition = newPosition;
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();

        if (inPosition && inPosition != previousPress)
        {
            OnPress.Invoke();

            previousPress = inPosition;
        }
    }

    private bool InPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, yMin, yMin + 0.01f);
        return transform.localPosition.y == inRange;
    }
}
