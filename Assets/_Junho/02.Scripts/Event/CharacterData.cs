using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterData : MonoBehaviour 
{
    public MeshFilter _characterForm; // CharacterForm Model

    public abstract void Init();
    protected abstract void OtherPlayerSkill();
    
}