using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Aggiunto per l'UnityEvent

public class ObjectCustOn : MonoBehaviour
{
    public UnityEvent OnCustEvent; // L'evento da eseguire

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    // Attiva l'oggetto desiderato
                    OnCustEvent.Invoke();
                }
            }
        }
    }
}
