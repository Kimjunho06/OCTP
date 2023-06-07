using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NestSystem : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        SaveSystem.Instance.Save();
        SaveSystem.Instance.Data.date++;
        //다음날로 넘어감
    }
}
