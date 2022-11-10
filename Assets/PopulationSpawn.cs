using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationSpawn : MonoBehaviour
{
    [SerializeField] private int numberOfMigrators;
    [SerializeField] private GameObject personPrefab;
    [SerializeField] private GameObject spawnObj;

    public List<GameObject> cities = new List<GameObject>();
    public List<GameObject> population = new List<GameObject>();

    [Range(2010,2020)]
    [SerializeField] private int year;

    public static PopulationSpawn Instance { get; set; }

    private void Awake()
    {
        Instance = this;
    }

    void Start()
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
            population.Add(person);

            int randomCity = Random.Range(0, cities.Count);

            //City city = cities[randomCity].GetComponent<City>();

            person.GetComponent<PopulationMigration>().cityObj = cities[randomCity];
            person.GetComponent<PopulationMigration>().SetGoal(person.GetComponent<PopulationMigration>().cityObj);

            /*bool housing = false;

            float[] salaryPerHouseTypes;
            if (DataManager.instance.salariesPerCity[randomCity].TryGetValue(year, out salaryPerHouseTypes))
            {
                for (int j = salaryPerHouseTypes.Length - 1; j >= 0; --j)
                {
                    if (person.GetComponent<PersonData>().salary > salaryPerHouseTypes[j])
                    {
                        person.GetComponent<PopulationMigration>().SetGoal(city.suburbs[j]);
                        housing = true;
                        break;
                    }
                }
            }*/

            /*for (int j = city.suburbs.Count - 1; j >= 0 ; --j)
            {


                //Debug.Log("city: " + cities[randomCity].name +  ". suburbs[" + j +"]");
                if(person.GetComponent<PersonData>().salary > )
                {
                    person.GetComponent<PopulationMigration>().SetGoal(city.suburbs[j]);
                    housing = true;
                    break;
                }
            }*/

            /*if (!housing)
            {
                Debug.Log("person: " + i + " cannot afford housing");
                person.GetComponent<PopulationMigration>().SetGoal(spawnObj);
            }*/

            /*int randomSuburb = Random.Range(-1, city.suburbs.Count);
            if (randomSuburb == -1)
                person.GetComponent<PopulationMigration>().SetGoal(cities[randomCity]);
            else
                person.GetComponent<PopulationMigration>().SetGoal(city.suburbs[randomSuburb]);*/
        }
    }

    [ContextMenu("Migrate Population")]
    public void MigratePopluation(float year)
    {
        foreach (var person in population)
        {
            person.GetComponent<PopulationMigration>().Migrate((int)year);
        }
    }
}
