using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;

    private Transform playerTrm = null; 
    public Transform PlayerTrm {
        get{
            if(playerTrm == null){
                playerTrm = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
            return playerTrm;
        }
    }
    void Awake()
    {
        Instance = GetComponent<GameManager>();
    }
}
