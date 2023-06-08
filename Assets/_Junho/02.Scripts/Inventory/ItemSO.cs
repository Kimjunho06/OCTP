using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject // 인벤토리 SO
{
    public int width = 1;
    public int height = 1;

    public string itemName;
    public Sprite itemicon;
    public int itemCost;
}
