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
        return (ulong)(level * Mathf.Pow(level, 5) - 1);
    }
}
