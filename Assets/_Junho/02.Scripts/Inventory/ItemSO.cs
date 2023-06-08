using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject // �κ��丮 SO
{
    public int width = 1;
    public int height = 1;

    public string itemName;
    public Sprite itemicon;
    public int itemCost;
}
