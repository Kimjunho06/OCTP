using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject // 인벤토리 SO
{
    public int width = 1;
    public int height = 1;

    public Sprite itemicon;
    public GameObject prefab; // 게임씬에 떨어진 모델
}
