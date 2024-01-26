using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerFollowCamera : MonoBehaviour
{
    public Transform target; // The target the camera will follow
    public float rotationSpeed = 5f; // Adjust the rotation speed as needed

    private CinemachineVirtualCamera virtualCamera;
    private Transform virtualCameraTransform;
    private Quaternion initialRotation;

    void Start()
    {
        // Get the CinemachineVirtualCamera component
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        if (virtualCamera != null)
        {
            virtualCameraTransform = virtualCamera.transform;
            initialRotation = virtualCameraTransform.rotation;
        }
        else
        {
            Debug.LogError("CinemachineVirtualCamera component not found!");
        }
    }

    void Update()
    {
        if (target != null && virtualCamera != null)
        {
            // Get the direction from the camera to the target
            Vector3 directionToTarget = target.position - virtualCameraTransform.position;
            directionToTarget.y = 0f; // Ignore the vertical component

            // Calculate the rotation needed to face the target
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Smoothly rotate towards the target rotation
            virtualCameraTransform.rotation = Quaternion.Slerp(
                virtualCameraTransform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );

            // Limit the camera rotation within 180 degrees in front of the initial direction
            ClampCameraRotation();
        }
    }

    void ClampCameraRotation()
    {
        // Calculate the difference in rotation from the initial rotation
        float angleDifference = Quaternion.Angle(initialRotation, virtualCameraTransform.rotation);

        // If the rotation exceeds 180 degrees, clamp it to 180 degrees
        if (angleDifference > 180f)
        {
            Quaternion maxRotation = Quaternion.RotateTowards(
                initialRotation,
                virtualCameraTransform.rotation,
                180f
            );

            // Apply the clamped rotation
            virtualCameraTransform.rotation = maxRotation;
        }
    }
}