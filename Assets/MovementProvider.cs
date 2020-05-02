using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementProvider : LocomotionProvider
{
    public List<XRController> controllers = null;

    private CharacterController characterController = null;
    private GameObject head = null;
    [SerializeField] private float moveSpeed = 1.0f;
    [SerializeField] private float gravityMultiplier = 1.0f;

    protected override void Awake()
    {
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;
    }

    void Start()
    {
        PositionController();
    }

    void FixedUpdate()
    {
        PositionController();
        CheckInput();
        ApplyGravity();
    }



    private void PositionController()
    {
        //get the head in local, playspace ground
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1f, 2f);
        characterController.height = headHeight;

        //Cut in half, add skin
        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2f;
        newCenter.y += characterController.skinWidth;

        //move the capsule in local space as well
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;

        //Apply
        characterController.center = newCenter;
    }

    private void CheckInput()
    {
        foreach (XRController controller in controllers)
        {
            if (controller.enableInputActions)
            {
                CheckForMovement(controller.inputDevice);
            }
        }
    }

    private void CheckForMovement(InputDevice device)
    {
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            StartMove(position);
        }
    }

    private void StartMove(Vector2 position)
    {
        Vector3 direction = new Vector3(position.x, 0f, position.y);
        Vector3 headRotationDirection = new Vector3(0f, head.transform.eulerAngles.y, 0f);

        direction = Quaternion.Euler(headRotationDirection) * direction;

        Vector3 movement = direction * moveSpeed;
        characterController.Move(movement * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        Vector3 gravity = new Vector3(0f, Physics.gravity.y * gravityMultiplier, 0f);
        gravity.y *= Time.deltaTime;

        characterController.Move(gravity);
    }
}
