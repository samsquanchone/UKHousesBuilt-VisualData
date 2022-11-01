using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
     //Dictionary float index's: 0: England, 1: Scotland
        Dictionary<int, float[]> countrys = new Dictionary<int, float[]>();
    // Start is called before the first frame update
    void Start()
    {
        
        
        //Populate Number of dwellings completed between 2010-2020 in UK
        countrys.Add(2010, new float[] {106700, 16940, 6720,700});
        countrys.Add(2011, new float[] {114000, 15280, 5750,700});
        countrys.Add(2012, new float[] {115600, 15050, 5540,700});
        countrys.Add(2013, new float[] {109400, 15130, 5410,700});
        countrys.Add(2014, new float[] {117800, 15610, 5520,700});
        countrys.Add(2015, new float[] {142500, 17230, 5450,700});
        countrys.Add(2016, new float[] {141900, 16930, 6450,700});
        countrys.Add(2017, new float[] {162500, 17450, 6880,700});
        countrys.Add(2018, new float[] {165500, 20160, 7640,700});
        countrys.Add(2019, new float[] {177900, 22670, 7420,700});
        countrys.Add(2020, new float[] {147900, 14830, 6420,700}); 

        
        
    }


    public void GetNumberOfHousesBuiltValuesForYear(int year)
    {
         float[] values;

         countrys.TryGetValue(year, out values); //Set local array values to values for the year 

         for(int i = 0; i < values.Length; i++) //Iterate over array (number of values for that year)
        {
        Debug.Log(year + " values:" + values[i]);
        }

        DataToVFX.instance.SetParticleAmount(values);
    }

   
}
