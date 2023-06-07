using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

        StartCoroutine(DelayCoroutine(1f, ()=>{
            _rb.velocity = Vector3.zero;
        }));
    }

    private IEnumerator DelayCoroutine(float duration, Action callback){
        yield return new WaitForSeconds(duration);
        callback.Invoke();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Player")){
            Destroy(gameObject);
        }
    }
}
