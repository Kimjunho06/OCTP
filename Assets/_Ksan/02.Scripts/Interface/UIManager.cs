using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private ExplainBar _explainBar;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        _explainBar = FindObjectOfType<ExplainBar>();
    }

    public void ShowExplainBar(Vector3 worldPos, string text) => _explainBar.Show(worldPos, text);

}
