using UnityEngine;


[CreateAssetMenu(fileName = "ShopMenu", menuName = "Scriptable Object/New shop Item", order = 1)]
public class ShopItemSO : ScriptableObject {
    public string title;
    public string description;
    public int baseCost;
}