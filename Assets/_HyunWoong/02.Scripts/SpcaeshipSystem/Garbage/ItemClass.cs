using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass : MonoBehaviour
{
    private Rigidbody _rb;
    private ItemSO _so;
    private void Awake() {
        _rb = GetComponent<Rigidbody>();
    }

    public void SetSO(ItemSO so){
        _so = so;
    }

    public void DropItem(Vector3 normal, float force, ForceMode mode){
        _rb.AddForce(normal * force, mode);

        DelayCoroutine(.5f, ()=>{
            _rb.velocity = Vector3.zero;
        });
    }

    private IEnumerator DelayCoroutine(float duration, Action callback){
        yield return new WaitForSeconds(duration);
        callback.Invoke();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Player")){
            print("Get Item");
            print(SaveSystem.Instance);//잘 나옴
            ++SaveSystem.Instance.Data.itemCnt;
            Destroy(gameObject);
        }
    }
}
