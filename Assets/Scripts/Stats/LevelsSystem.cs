using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsSystem : MonoBehaviour
{
    public static LevelsSystem Instance = null;

    private void Awake()
    {
        Instance = this;
    }

    public ulong CalculateNeedMoney(uint level)
    {
        return (ulong)(2*Mathf.Pow(level, 6.252f));
    }

    
}
