using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MainSceneManager : MonoBehaviour
{
    public static MainSceneManager instance => m_instance;
    private static MainSceneManager m_instance;
    public TextMeshProUGUI display_max_population;
    public float minSalary;
    public float maxSalary;

    [SerializeField] private GameObject spawnObj;
    [SerializeField] private int numberOfMigrators = 36;
    [SerializeField] private GameObject personPrefab;

    [SerializeField] private List<GameObject> cities = new List<GameObject>();

    public void Awake()
    {
        m_instance = this;

        display_max_population.text = SetupSceneManager.ssmInstance.max_population;
        minSalary = float.Parse(SetupSceneManager.ssmInstance.min_salary);
        maxSalary = float.Parse(SetupSceneManager.ssmInstance.max_salary);

        Debug.Log("MinSal: " +  minSalary + "MaxSal: " + maxSalary);
    }

    private void Start()
    {
        SpawnPopulation();
    }

    /// <summary>
    /// spawnns a number of migrators around a spawn area with some variation to avoid stacking
    /// </summary>
    void SpawnPopulation()
    {
        for (int i = 0; i < numberOfMigrators; i++)
        {
            GameObject person = Instantiate(personPrefab, spawnObj.transform.position + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)), Quaternion.identity);
            //person.GetComponent<PersonData>().salary;
            //person.GetComponent<PopulationMigration>().cityObj = this.gameObject;

            int randomCity = Random.Range(0, cities.Count);
            City city = cities[randomCity].GetComponent<City>();

            bool housing = false;
            for (int j = city.suburbs.Count - 1; j >= 0 ; --j)
            {
                //Debug.Log("city: " + cities[randomCity].name +  ". suburbs[" + j +"]");
                if(person.GetComponent<PersonData>().salary > city.suburbs[j].GetComponent<Suburb>().housePrice)
                {
                    person.GetComponent<PopulationMigration>().SetGoal(city.suburbs[j]);
                    housing = true;
                    break;
                }
            }

            if(!housing)
            {
                Debug.Log("person: " + i + " cannot afford housing");
                person.GetComponent<PopulationMigration>().SetGoal(spawnObj);
            }

            /*int randomSuburb = Random.Range(-1, city.suburbs.Count);
            if (randomSuburb == -1)
                person.GetComponent<PopulationMigration>().SetGoal(cities[randomCity]);
            else
                person.GetComponent<PopulationMigration>().SetGoal(city.suburbs[randomSuburb]);*/
        }
    }
}
