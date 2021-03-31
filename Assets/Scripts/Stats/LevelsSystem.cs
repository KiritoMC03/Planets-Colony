using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class LevelsSystem : MonoBehaviour
{
    public static LevelsSystem Instance = null;

    [SerializeField] private ulong _moneyForBuildFactory = (ulong)Mathf.Pow(10, 9);
    private BigInteger _moneyForBuild;

    private void Awake()
    {
        Instance = this;
        _moneyForBuild = _moneyForBuildFactory;
        
    }

    public BigInteger CalculateNeedMoney(uint level)
    {
        if(level == 1)
        {
            return _moneyForBuild;
        }

        return (BigInteger)(2 * Mathf.Pow(level, 6.252f));
    }

    
}
