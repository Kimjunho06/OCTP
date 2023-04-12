using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
//using core;

public class ExplainBar : MonoBehaviour
{
    private VisualElement _root;
    private VisualElement _explainBar;
    private Label _explainText;
    private UIDocument _document;

    private Vector3 _showWorldPos;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
    }

    private void OnEnable()
    {
        _root = _document.rootVisualElement;
        _explainBar = _root.Q<VisualElement>("ExplainBar");
        _explainText = _root.Q<Label>("ExplainText");

    }

    public void Show(Vector3 worldPos, string text)
    {
        //Camera.main 나중에 코어 안에 있는 값으로 바꿔야 함
        Vector2 uiPos = RuntimePanelUtils.CameraTransformWorldToPanel(_root.panel, worldPos, Camera.main);

        float deltaY = -100f;

        //바 위치 옮기기
        _explainBar.style.left = uiPos.x - _explainBar.layout.width * 0.5f;
        _explainBar.style.top = uiPos.y + deltaY;

        //Text설정
        _explainText.text = text;
    }
}
