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

}
