using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemDropper : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _duration;

    [SerializeField] private Slider _gauge;
    private bool _isFound = false;

    public UnityEvent OnActionEndTrigger = null;

    public void Interact()
    {
        if (!_isFound)
        {
            _gauge.gameObject.SetActive(true);
            _isFound = true;
            print($"is Interacted!! : {this.name}");
            StartCoroutine(FillGauge(_duration));
        }
    }

    private IEnumerator FillGauge(float duration)
    {
        while (true)
        {
            duration -= Time.deltaTime;
            _gauge.value = 1 - duration;
            if (duration <= 0)
            {
                duration = 0;
                _gauge.value = 0;
                _gauge.gameObject.SetActive(false);
                break;
            }
            yield return null;
        }

        OnActionEndTrigger.Invoke();
    }
}
