using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardPlayAnimation : MonoBehaviour
{
    // Make the Animator variable public for easy assignment in the Unity Editor
    public Animator animator;

    // Make the key and trigger name public for easy customization in the Unity Editor
    public KeyCode triggerKey = KeyCode.Y;
    public string animationTrigger = "Enter";

    private void Start()
    {
        // Make sure there is an Animator component attached
        if (animator == null)
        {
            Debug.LogError("Animator component not assigned. Please assign an Animator component.");
        }
    }

    private void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(triggerKey))
        {
            // Trigger the animation
            TriggerAnimation();
        }
    }

    public void TriggerAnimation()
    {
        // Check if the Animator component is available
        if (animator != null)
        {
            // Trigger the specified animation
            animator.SetTrigger(animationTrigger);
        }
        else
        {
            Debug.LogError("Animator component is not assigned. Please assign an Animator component.");
        }
    }
}