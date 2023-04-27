using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HP : MonoBehaviour
{
    [SerializeField]
    public  float maxHP;
    private float crtHP;

    private AIBrain _brain;
    private Camera _mainCam;

    private UIDocument _document;
    private VisualElement _root;
    private VisualElement _bar;
    private VisualElement _healthBar;

    private void Awake()
    {
        crtHP = maxHP;
        _mainCam = Camera.main;
        _brain = GameObject.Find("Monster").GetComponent<AIBrain>();
        _document = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _root = _document.rootVisualElement;
        _healthBar = _root.Q<VisualElement>("HealthBar");
        _bar = _root.Q<VisualElement>("Bar");
    }

    private void LateUpdate()
    {
        ResetHealth();

        Vector3 worldPos = _brain.transform.position;
        Vector2 uiPos = RuntimePanelUtils.CameraTransformWorldToPanel(_root.panel, worldPos, _mainCam);

        float deltaY = -100f;


        _healthBar.style.left = uiPos.x - _healthBar.layout.width * 0.5f;
        _healthBar.style.top = uiPos.y + deltaY;
    }

    public void OnHealthBarUpdate()
    {
        _bar.style.width = new Length(crtHP / maxHP, LengthUnit.Percent);
        _healthBar.visible = true;
    }

    public void DamagedHealth(float damage)
    {
        crtHP -= damage;
        OnHealthBarUpdate();
    }

    public void ResetHealth()
    {
        if (!_brain.IsBattled)
        {
            crtHP = maxHP;
            _healthBar.visible = false;
        }
    }


}
