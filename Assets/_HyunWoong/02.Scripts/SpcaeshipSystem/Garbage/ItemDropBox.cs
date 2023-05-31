using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDropBox : MonoBehaviour
{
    [SerializeField] private ItemTable _table;

    [SerializeField]
    private InventoryGrid _grid;

    private InventoryItem overlapItem;

    public void OnBox(bool value) => gameObject.SetActive(value);

    public void InsertItem()
    {

    }

    [ContextMenu("Randomitem")]
    public void RandomItem(){
        StartCoroutine(CreateItem());
    }

    private IEnumerator CreateItem() {
        for (int i = 0; i < _table.DropItem.Count; ++i)
        {
            GameObject obj = new GameObject();

            obj.name = "item_" + i.ToString();
            obj.transform.SetParent(_grid.transform);

            obj.AddComponent<InventoryItem>();
            obj.AddComponent<Image>();

            InventoryItem inven = obj.GetComponent<InventoryItem>();

            inven.Set(_table.DropItem[Random.Range(0, 2)]);

            inven.onGridPositionX = Random.Range(0, 7);
            inven.onGridPositionY = Random.Range(0, 6);

            print(inven.gameObject.name);

            bool complete = _grid.PlaceItem(inven, inven.onGridPositionX, inven.onGridPositionY, ref overlapItem);

            if (complete)
            {
                inven = null; // ???? ?????? ?????

                if (overlapItem != null) // ????? ????? ???????? ????
                {
                    inven = overlapItem; // ??? ????
                    overlapItem = null; // ????? ?????? ?????
                }
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}
