using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineManager : MonoBehaviour
{
    public static CombineManager Instance;

    public List<CombineRecipeSO> recipes;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multy CombineManager");
        }
        Instance = this;
    }

    public ItemSO Combine(ItemSO first, ItemSO second)
    {
        for (int i = 0; i < recipes.Count; i++)
        {
            if (recipes[i].items[0] == first)
            {
                if (recipes[i].items[1] == second)
                {
                    return recipes[i].items[2];
                }
                else
                {
                    return null;    
                }
            }
            else if (recipes[i].items[0] == second)
            {
                if (recipes[i].items[1] == first)
                {
                    return recipes[i].items[2];
                }
                else
                {
                    return null;    
                }
            }
        }
        return null;      
    }
}
