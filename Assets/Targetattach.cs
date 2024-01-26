using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetattach : MonoBehaviour
{
    public List<GameObject> Targetlist; // List of targets from RandomTargetXls.
    public GameObject objectX; // Reference to the object you want to make a child of the targets.

    private void Update()
    {
        foreach (GameObject currentObject in Targetlist)
        {
            // Check if the current target is active (visible).
            if (currentObject.activeSelf)
            {
                // Set objectX's position and rotation to match the current target.
                objectX.transform.position = currentObject.transform.position;
                objectX.transform.rotation = currentObject.transform.rotation;
            }
            else
            {
                // Optionally, you can remove objectX from being a child of the current target when it's not active.
                objectX.transform.SetParent(null);
            }
        }
    }
}