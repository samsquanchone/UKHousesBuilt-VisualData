using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField] private int numberOfMigrators = 4; 
    [SerializeField] private GameObject personPrefab;

    [SerializeField] private float suburbDistance = 2;
    [SerializeField] private GameObject suburbPrefab;
    public List<GameObject> suburbs = new List<GameObject>();

    private void Awake()
    {
        SpawnPopulation();
    }

    void Start()
    {

    }

    [ContextMenu("SpawnSuburbs")]
    void SpawnSuburbs()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject suburb = Instantiate(suburbPrefab, gameObject.transform);

            suburb.GetComponent<Suburb>().houseType = (HouseType)i;
            suburb.name = suburb.GetComponent<Suburb>().houseType.ToString().ToLower();

            switch (i)
            {
                case 0:
                    suburb.transform.localPosition = new Vector3(0 , 0, -suburbDistance);
                    break;
                case 1:
                    suburb.transform.localPosition = new Vector3(0, 0, suburbDistance);
                    break;
                case 2:
                    suburb.transform.localPosition = new Vector3(suburbDistance, 0, 0);
                    break;
                case 3:
                    suburb.transform.localPosition = new Vector3(-suburbDistance, 0, 0);
                    break;
                default:
                    break;
            }
            suburbs.Add(suburb);
        }
    }

    [ContextMenu("DestroySuburbs")]
    void DestroySuburbs()
    {
        for (int i = 0; i < suburbs.Count; i++)
        {
            DestroyImmediate(suburbs[i]);
        }
        suburbs.Clear();
    }

    /// <summary>
    /// spawnns a number of migrators around a spawn area with some variation to avoid stacking
    /// </summary>
    void SpawnPopulation()
    {
        for (int i = 0; i < numberOfMigrators; i++)
        {
            GameObject person = Instantiate(personPrefab, this.transform.position + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)), Quaternion.identity);
            person.GetComponent<PopulationMigration>().cityObj = this.gameObject;
            person.GetComponent<PopulationMigration>().SetGoal(this.gameObject);
        }
    }

    /*[ContextMenu("MigratePopulation")]
    void MigratePopulation()
    {
        for (int i = 0; i < numberOfMigrators; i++)
        {
            GameObject person = Instantiate(personPrefab, this.transform.position, Quaternion.identity);
            person.GetComponent<PopulationMigration>().migrationPoints = suburbs;
            person.GetComponent<PopulationMigration>().Migrate();

            // get random salary
            // if threshold reaches certain amount THEN migrate
        }

    }*/

    void Update()
    {
        
    }
}
