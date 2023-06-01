using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private ItemTable _table;
    [SerializeField] private GameObject itemPrefab;

    private Vector3 _dropNormal;
    private int _randNum = 0;

    public void DropItem(Transform pos){
        int randomItemIdx = 0;
        _randNum = Random.Range(0, 5);
        StartCoroutine(InsItem(randomItemIdx, pos));
    }

    private IEnumerator InsItem(int num, Transform pos){
        for(int i = 0; i < _randNum; ++i){
            float x = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);
            num = Random.Range(0, _table.DropItem.Count);
            GameObject obj = Instantiate(itemPrefab,pos.position , Quaternion.identity);
            _dropNormal = new Vector3(x, 1, z);
            obj.GetComponent<ItemClass>().SetSO(_table.DropItem[num]);
            obj.GetComponent<ItemClass>().DropItem(_dropNormal, 4, ForceMode.Impulse);
            yield return new WaitForSeconds(.2f);
        }
    }
}
