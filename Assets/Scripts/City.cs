using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField] private float suburbDistance = 2;
    [SerializeField] private GameObject suburbPrefab;
    public List<GameObject> suburbs = new List<GameObject>();

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
