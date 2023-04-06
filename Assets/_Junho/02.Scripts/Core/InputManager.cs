using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public Action OnInteractionEvent;

    public KeyCode interactionKey;

    private void Update()
    {
        OnInteraction();   
    }

    private void OnInteraction()
    {
        if (Input.GetKeyDown(interactionKey)) 
        {
            OnInteractionEvent?.Invoke();
        }
    }
}
