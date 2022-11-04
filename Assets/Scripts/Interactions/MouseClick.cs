using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseClick : MonoBehaviour
{
    private float[] values;
    private float setYear = 2010;

    public TMP_Text[] cityDataText;
    public TMP_Text cityText;

    public TMP_Text personNameText;
    public TMP_Text personSalaryText;

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

            if (Physics.Raycast(ray,out hit, 10000f))
            {
                if (hit.transform.CompareTag("City"))
                {
                    Debug.Log(hit.transform.name);
                    //GetData of city 
                    hit.transform.gameObject.GetComponent<CityPrices>().cityData.cityDataByYear.TryGetValue((int)setYear, out values);
                    if (values != null)
                    {
                        for (int i = 0; i < values.Length; i++) //Iterate over array (number of values for that year)
                        {
                            Debug.Log(hit.transform.name + " values:" + values[i]);
                        }
                    }
                    SetCityDataUI(hit.transform.name, values);

                }

                else if (hit.transform.CompareTag("Person"))
                {
                    SetPersonDataUI(hit.transform.gameObject.GetComponent<PersonData>().name, hit.transform.gameObject.GetComponent<PersonData>().salary);
                }
            }
        }
    }

    public void SetYear(float year)
    {
        setYear = year;
        Debug.Log(year);
    }

     void SetCityDataUI(string name, float[] cityDataValues)
    {
        cityText.text = "City: " + name;

        if (cityDataValues != null)
        {
            for (int i = 0; i < cityDataValues.Length; i++)
            {
                cityDataText[i].text = textUINames[i] + "£" + cityDataValues[i];
            }
        }
       
    }

    void SetPersonDataUI(string name, float salary)
    {
        personNameText.text = name;
        personSalaryText.text = "£" + salary;
    }

}
