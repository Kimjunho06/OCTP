using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SpaceshipData {
    public Sprite sprite;
    public int index;
};

[CreateAssetMenu(menuName = "SO/ItemTable")]
public class ItemTable : ScriptableObject {
    public List<SpaceshipData> _dataList = new List<SpaceshipData>();
}
