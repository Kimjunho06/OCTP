using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="SO/ItemTable")]
public class ItemTable : ScriptableObject
{
    public List<ItemSO> DropItem = new List<ItemSO>();
}
