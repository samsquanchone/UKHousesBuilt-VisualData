using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   // [SerializeField] private housesBuiltJSON;

    //Dictionary float index's: 0: England, 1: Scotland
        public GenericDictionary<int, float[]> housesBuiltDictionary;


        Dictionary<int, float[]> countrys = new Dictionary<int, float[]>();
    // Start is called before the first frame update
    void Start()
    {
        LoadDataFromFile();

        //Populate Number of dwellings completed between 2010-2020 in UK
        countrys.Add(2010, new float[] { 106700, 16940, 6720, 700 });
        countrys.Add(2011, new float[] { 114000, 15280, 5750, 700 });
        countrys.Add(2012, new float[] { 115600, 15050, 5540, 700 });
        countrys.Add(2013, new float[] { 109400, 15130, 5410, 700 });
        countrys.Add(2014, new float[] { 117800, 15610, 5520, 700 });
        countrys.Add(2015, new float[] { 142500, 17230, 5450, 700 });
        countrys.Add(2016, new float[] { 141900, 16930, 6450, 700 });
        countrys.Add(2017, new float[] { 162500, 17450, 6880, 700 });
        countrys.Add(2018, new float[] { 165500, 20160, 7640, 700 });
        countrys.Add(2019, new float[] { 177900, 22670, 7420, 700 });
        countrys.Add(2020, new float[] { 147900, 14830, 6420, 700 });



    }

    //Look up getRandomPoint on mesh github for particle spawning
    public void GetNumberOfHousesBuiltValuesForYear(float year)
    {
        float[] values;

        countrys.TryGetValue((int)year, out values); //Set local array values to values for the year 

        for (int i = 0; i < values.Length; i++) //Iterate over array (number of values for that year)
        {
            Debug.Log(year + " values:" + values[i]);
        }

        DataToVFX.instance.SetParticleAmount(values);
    }

    StreamReader sr;
    private void LoadDataFromFile()
    {
        Dictionary<int, float[]> countryHousingDictionary = new Dictionary<int, float[]>();
        string path = (Application.streamingAssetsPath + "/HouseDevelop.csv");
        Debug.Log(path);
        if (sr != null)
            sr.Close();
        sr = new StreamReader(path);
        string line = sr.ReadLine();
        while (!sr.EndOfStream)
        {
            Debug.Log("LINE :: " + line);
            if (!string.IsNullOrEmpty(line))
            {
                string[] values = line.Split(',');
                List<float> floatList = new List<float>();
                float f;
                for(int i=0; i<values.Length; i++)
                {
                    if(float.TryParse(values[i], out f))
                    {
                        floatList.Add(f);
                    }
                }
                if(floatList.Count > 0)
                {
                    countryHousingDictionary.Add((int)floatList[0], floatList.GetRange(1,floatList.Count-1).ToArray());
                    floatList.Clear();
                }
            }
            Debug.Log("DICTIONARy :: " + countryHousingDictionary.Count);
        }
        sr.Close();
    }
}
