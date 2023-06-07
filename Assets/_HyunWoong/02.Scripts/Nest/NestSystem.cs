using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NestSystem : MonoBehaviour, IInteractable
{
    [SerializeField]
    private bool _isInNest = false;

    public void Interact()
    {
        if(!_isInNest) return;

        SaveSystem.Instance.Save();
        SaveSystem.Instance.Data.date++;
        //다음날로 넘어감
    }
}
