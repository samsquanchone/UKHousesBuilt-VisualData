using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField] private int numberOfMigrators = default; 
    [SerializeField] private GameObject personPrefab;

    [SerializeField] private GameObject suburbPrefab;

    [SerializeField] private List<GameObject> suburbs = new List<GameObject>();

    void Start()
    {
        
    }

    void SetAverageHousePrice()
    {

    }

    [ContextMenu("Spawn Suburb")]
    void SpawnSuburbs()
    {
        GameObject suburb = Instantiate(suburbPrefab, this.transform.position, Quaternion.identity);

    }

    [ContextMenu("MigratePopulation")]
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

    }

    void Update()
    {
        
    }
}
