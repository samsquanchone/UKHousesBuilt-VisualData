using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MigrationManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    public void GetHousePricePerRegionForYear(float year)
    {
        //Get values for year here, provide this to another function that each instance of nav agent can access, so when on UI year change nav agent checks house price for the year (will need to group nav agents into regions after spawn)
    }

}