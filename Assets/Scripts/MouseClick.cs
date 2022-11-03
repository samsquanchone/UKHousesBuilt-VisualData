using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    private float[] values;
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
                    hit.transform.gameObject.GetComponent<CityPrices>().cityData.cityDataByYear.TryGetValue((int)2010, out values);
                    for (int i = 0; i < values.Length; i++) //Iterate over array (number of values for that year)
                    {
                        Debug.Log(hit.transform.name + " values:" + values[i]);
                    }
                   
                }
            }
        }
    }
}
