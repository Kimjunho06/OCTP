using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject // �κ��丮 SO
{
    public int width = 1;
    public int height = 1;

    public Sprite itemicon;
    public GameObject prefab; // ���Ӿ��� ������ ��
}
