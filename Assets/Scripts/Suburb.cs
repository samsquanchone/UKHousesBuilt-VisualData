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

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
