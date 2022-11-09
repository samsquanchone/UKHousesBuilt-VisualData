using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance => m_Instance;
    private static DataManager m_Instance; 
    
    //General house price by reigion 2010-2011 dictionary
    public GenericDictionary<int, float[]> houseDevelopedByRegion;
    public GenericDictionary<int, float[]> housePriceByRegion;

    //Salary Needed for each house type 2010-2020 dictionaries (For each city)
    public GenericDictionary<int, float[]> salaryNeededLeicester;
    public GenericDictionary<int, float[]> salaryNeededCambridge;
    public GenericDictionary<int, float[]> salaryNeededNewcastle;
    public GenericDictionary<int, float[]> salaryNeededLondon;
    public GenericDictionary<int, float[]> salaryNeededBrighton;
    public GenericDictionary<int, float[]> salaryNeededBristol;
    public GenericDictionary<int, float[]> salaryNeededManchester;
    public GenericDictionary<int, float[]> salaryNeededBirmingham;
    public GenericDictionary<int, float[]> salaryNeededLeeds;


    private float[] values;

    void Awake()
    {
        m_Instance = this;
        LoadDataFromFile(houseDevelopedByRegion, "HouseDevelop.csv");
        LoadDataFromFile(housePriceByRegion, "HousePrices-UkRegions.csv");

        LoadDataFromFile(salaryNeededLeicester, "Leicester-SalaryNeeded.csv");
        LoadDataFromFile(salaryNeededCambridge, "Cambridge-SalaryNeeded.csv");
        LoadDataFromFile(salaryNeededNewcastle, "Newcastle-SalaryNeeded.csv");
        LoadDataFromFile(salaryNeededLondon, "London-SalaryNeeded.csv");
        LoadDataFromFile(salaryNeededBrighton, "Brighton-SalaryNeeded.csv");
        LoadDataFromFile(salaryNeededBristol, "Bristol-SalaryNeeded.csv");
        LoadDataFromFile(salaryNeededManchester, "Manchester-SalaryNeeded.csv");
        LoadDataFromFile(salaryNeededBirmingham, "Birmingham-SalaryNeeded.csv");
        LoadDataFromFile(salaryNeededLeeds, "Leeds-SalaryNeeded.csv");
    }
    

    StreamReader sr;
    private void LoadDataFromFile(GenericDictionary<int, float[]> dictionary, string fileName)
    {
        //Dictionary<int, float[]> countryHousingDictionary = new Dictionary<int, float[]>();
        string path = (Application.streamingAssetsPath + "/" + fileName);
        Debug.Log(path);
        if (sr != null)
            sr.Close();
        sr = new StreamReader(path);
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            Debug.Log("LINE :: " + line);
            if (!string.IsNullOrEmpty(line))
            {
                string[] values = line.Split(',');
                List<float> floatList = new List<float>();
                float f;
                for (int i = 0; i < values.Length; i++)
                {
                    if (float.TryParse(values[i], out f))
                    {
                        floatList.Add(f);
                    }
                }
                if (floatList.Count > 0)
                {
                    dictionary.Add((int)floatList[0], floatList.GetRange(1, floatList.Count - 1).ToArray());
                    floatList.Clear();
                }
            }
            Debug.Log("DICTIONARY :: " + dictionary.Count);
        }
        sr.Close();
    }

   
}
