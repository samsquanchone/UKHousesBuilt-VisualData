using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class migration : MonoBehaviour
{
    [SerializeField] private int numberOfMigrators = default; 
    [SerializeField] private GameObject personPrefab;

    [SerializeField] private List<GameObject> suburbs = new List<GameObject>();

    void Start()
    {
        
    }

    void SpawnSuburbs()
    {

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
