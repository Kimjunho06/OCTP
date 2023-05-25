using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipConstruction : MonoBehaviour, IInteractable
{
    public List<bool> isCollecting = new List<bool>();
    public GameObject[] objs;

    private void Start() {
        Sort();
    }

    private void Sort(){
        for(int i = 0; i < objs.Length; ++i){
            objs[i].SetActive(isCollecting[i]);
        }
    }

    public void Interact()
    {
        
    }
}
