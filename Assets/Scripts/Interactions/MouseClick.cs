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
    public static MouseClick Instance;
    private void Awake()
    {
        Instance=this;
    }

    [SerializeField] private string[] textUINames;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //If rayhit hits object, output hit variable
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                //If the object that is hit is of tag "City" get the values for the houseByPriceRegion dictionary (from DataManager instance) for the current slider UI year value
                if (hit.transform.CompareTag("City"))
                {
                    Debug.Log(hit.transform.name);

                    CameraControl.Instance.FocusOn(hit.transform);
                    if (DataManager.instance.housePriceByRegion.TryGetValue((int)setYear, out price))
                    {
                        //Send values of objects data script, as well as dictionary values for the current year to the SetCityDataUI function
                        SetCityDataUI(hit.transform.name, price, hit.transform.gameObject.GetComponent<CityPrices>().cityData.dataIndex, hit.transform.gameObject.GetComponent<CityPrices>().cityData.citySalaryNeededDictionaryName);

                    }


                }

                //If the object that is hit by ray is of tag "Person" send the personData script variable values to the SetPersonDataUI function
                else if (hit.transform.CompareTag("Person"))
                {
                    SetPersonDataUI(hit.transform.gameObject.GetComponent<PersonData>().personName, hit.transform.gameObject.GetComponent<PersonData>().salary);
                }
            }
        }
    }

    //Set the local current year based off slider changed value (slider triggers this function and supplies the argument)
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

        //Compare string variable name of city hit by ray to the dictionary name for the cities salary needed dictionary, then supply UI values based off the dictionary values for the current year
        if (cityDictionaryName == "salaryNeededLeicester")
        {
            if (DataManager.instance.salaryNeededLeicester.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + " £" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededCambridge")
        {
            if (DataManager.instance.salaryNeededCambridge.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + " £" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededNewcastle")
        {
            if (DataManager.instance.salaryNeededNewcastle.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + " £" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededLondon")
        {
            if (DataManager.instance.salaryNeededLondon.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + " £" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededBrighton")
        {
            if (DataManager.instance.salaryNeededBrighton.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + " £" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededBristol")
        {
            if (DataManager.instance.salaryNeededBristol.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + " £" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededManchester")
        {
            if (DataManager.instance.salaryNeededManchester.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + " £" + salaryNeededValues[i];
                }
            }
        }

        if (cityDictionaryName == "salaryNeededBirmingham")
        {
            if (DataManager.instance.salaryNeededBirmingham.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + " £" + salaryNeededValues[i];
                }
            }
        }

        else if (cityDictionaryName == "salaryNeededLeeds")
        {
            if (DataManager.instance.salaryNeededLeeds.TryGetValue((int)setYear, out salaryNeededValues))
            {
                for (int i = 0; i < salaryNeededValues.Length; i++)
                {
                    cityDataText[i].text = textUINames[i] + " £" + salaryNeededValues[i];
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
