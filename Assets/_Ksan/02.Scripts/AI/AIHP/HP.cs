using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class HP : MonoBehaviour
{
    [SerializeField]
    public float maxHP;
    public float crtHP { get; private set; }

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
        _brain = transform.parent.GetComponent<AIBrain>();
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
        ShowHPBar();

    }

    private void ShowHPBar()
    {
        float dist = Vector3.Distance(_brain.transform.position, _brain.Player.transform.position);

        if (!_brain.IsBattled || dist > 20)
        {
            _healthBar.visible = false;
            return;
        }
        else
            _healthBar.visible = true;

        Vector3 worldPos = _brain.transform.position;
        Vector2 uiPos = RuntimePanelUtils.CameraTransformWorldToPanel(_root.panel, worldPos, _mainCam);

        float deltaY = -100f;

        _healthBar.style.left = uiPos.x - _healthBar.layout.width * 0.5f;
        _healthBar.style.top = uiPos.y + deltaY;

        //거리가 50까지 보인다고 하면
        Vector3 scale = Vector3.one * Mathf.Lerp(0, 1f, 1 - dist / 20);
        scale.z = 0;

        _healthBar.style.scale = new Scale(scale);
    }

    public void OnHealthBarUpdate()
    {
        _bar.style.width = new Length(crtHP / maxHP * 100, LengthUnit.Percent);
    }

    public void DamagedHealth(float damage)
    {
        crtHP -= damage;
        OnHealthBarUpdate();
    }


}
