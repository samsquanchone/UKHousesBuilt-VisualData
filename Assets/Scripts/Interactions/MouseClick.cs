using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseClick : MonoBehaviour
{
    private float[] values;
    private float[] price;
    private float setYear = 2010;

    public TMP_Text[] cityDataText;
    public TMP_Text cityText;
    public TMP_Text cityAvrgPriceText;

    public TMP_Text personNameText;
    public TMP_Text personSalaryText;
    public TMP_Text yearText;

    [SerializeField] private string[] textUINames;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 10000f))
            {
                if (hit.transform.CompareTag("City"))
                {
                    Debug.Log(hit.transform.name);
                    //GetData of city 
                   /* hit.transform.gameObject.GetComponent<CityPrices>().cityData.cityDataByYear.TryGetValue((int)setYear, out values);
                    if (values != null)
                    {
                        for (int i = 0; i < values.Length; i++) //Iterate over array (number of values for that year)
                        {
                            Debug.Log(hit.transform.name + " values:" + values[i]);
                        }
                    } */
                    if (DataManager.instance.housePriceByRegion.TryGetValue((int)setYear, out price))
                    {

                        SetCityDataUI(hit.transform.name, price, hit.transform.gameObject.GetComponent<CityPrices>().cityData.dataIndex, hit.transform.gameObject.GetComponent<CityPrices>().cityData.citySalaryNeededDictionaryName);

                    }


                }

                else if (hit.transform.CompareTag("Person"))
                {
                    SetPersonDataUI(hit.transform.gameObject.GetComponent<PersonData>().personName, hit.transform.gameObject.GetComponent<PersonData>().salary);
                }
            }
        }
    }

    public void SetYear(float year)
    {
        yearText.text = year.ToString();
        setYear = year;
        Debug.Log(year);
    }

    void SetCityDataUI(string cityName, float[] averageValues, int averageValuesIndex, string cityDictionaryName)
    {
        float[] salaryNeededValues;
        cityText.text = cityName;
        cityAvrgPriceText.text = "Average house price: " + "£" + averageValues[averageValuesIndex];

        if (cityDictionaryName == "salaryNeededLeicester")
        {
            if (DataManager.instance.salaryNeededLeicester.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + "£" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededCambridge")
        {
            if (DataManager.instance.salaryNeededCambridge.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + "£" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededNewcastle")
        {
            if (DataManager.instance.salaryNeededNewcastle.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + "£" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededLondon")
        {
            if (DataManager.instance.salaryNeededLondon.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + "£" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededBrighton")
        {
            if (DataManager.instance.salaryNeededBrighton.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + "£" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededBristol")
        {
            if (DataManager.instance.salaryNeededBristol.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + "£" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededManchester")
        {
            if (DataManager.instance.salaryNeededManchester.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + "£" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededBirmingham")
        {
            if (DataManager.instance.salaryNeededBirmingham.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + "£" + salaryNeededValues[i];
                }
            }
        }

        else if (cityDictionaryName == "salaryNeededLeeds")
        {
            if (DataManager.instance.salaryNeededLeeds.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + "£" + salaryNeededValues[i];
                }
            }
        }


        /* if (cityDataValues != null)
         {
             for (int i = 0; i < cityDataValues.Length; i++)
             {
                 cityDataText[i].text = textUINames[i] + "£" + cityDataValues[i];
             }
         }
        */

    }

    void SetPersonDataUI(string name, float salary)
    {
        personNameText.text = name;
        personSalaryText.text = "£" + salary;
    }

}
