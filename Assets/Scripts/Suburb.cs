using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum HouseType
{
    FLAT,
    TERRACED,
    SEMIDETACHED,
    DETACHED
}

public class Suburb : MonoBehaviour
{
    public HouseType houseType;
    public float housePrice = 0;

    void Start()
    {
        switch (houseType)
        {
            case HouseType.FLAT:
                housePrice = 1;
                break;
            case HouseType.TERRACED:
                housePrice = 2;
                break;
            case HouseType.SEMIDETACHED:
                housePrice = 3;
                break;
            case HouseType.DETACHED:
                housePrice = 4;
                break;
            default:
                Debug.LogWarning("Incorrect house type");
                break;
        }
    }

    void Update()
    {
        
    }
}
