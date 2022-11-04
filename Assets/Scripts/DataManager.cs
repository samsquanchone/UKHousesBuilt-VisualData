using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance  => m_Instance;
    private static DataManager m_Instance;
    //Dictionary float index's: 0: England, 1: Scotland
    //public GenericDictionary<int, float[]> housesBuiltDictionary;
    public GenericDictionary<int, float[]> housePriceByRegion;

<<<<<<< Updated upstream
    // Start is called before the first frame update
    void Start()
    {
        LoadDataFromFile(housePriceByRegion);
=======
    private float[] values;

    void Awake()
    {
        m_Instance = this;
    }
    void Start()
    {
        
        LoadDataFromFile(houseDevelopedByRegion, "HouseDevelop.csv");
        LoadDataFromFile(housePriceByRegion, "HousePrices-UkRegions.csv");
>>>>>>> Stashed changes
    }

    //Look up getRandomPoint on mesh github for particle spawning
    /*public void GetNumberOfHousesBuiltValuesForYear(float year)
    {
        float[] values;

        countrys.TryGetValue((int)year, out values); //Set local array values to values for the year 

        for (int i = 0; i < values.Length; i++) //Iterate over array (number of values for that year)
        {
            Debug.Log(year + " values:" + values[i]);
        }

        DataToVFX.instance.SetParticleAmount(values);
    }*/

    StreamReader sr;
    private void LoadDataFromFile(GenericDictionary<int, float[]> dictionary)
    {
        //Dictionary<int, float[]> countryHousingDictionary = new Dictionary<int, float[]>();
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
                    dictionary.Add((int)floatList[0], floatList.GetRange(1,floatList.Count-1).ToArray());
                    floatList.Clear();
                }
            }
            Debug.Log("DICTIONARY :: " + dictionary.Count);
        }
        sr.Close();
    }

    public float GetSpecificValue(float year, int index)
    {
        Debug.Log("Hey hey " + year);
        bool hasValue = housePriceByRegion.TryGetValue(2012, out values);
        if(hasValue)
        {
            float value;
            Debug.Log("shiiii" + values[2]);
            value = values[index];
            return value;

        }

        return 5;

    }
}
