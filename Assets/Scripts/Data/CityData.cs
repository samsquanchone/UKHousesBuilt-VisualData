using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class CityData : ScriptableObject
{
    public GenericDictionary<int, float[]> cityDataByYear;
    public int dataIndex;
    public string citySalaryNeededDictionaryName;


}
