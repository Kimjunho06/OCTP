using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.ShowExplainBar(transform.position, "이것은 설명 텍스트 테스트");
    }

    
}
