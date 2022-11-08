
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PopulationMigration : MonoBehaviour
{
    public GameObject cityObj;
    private City city;
    public List<GameObject> migrationPoints = new List<GameObject>();

    [SerializeField] private Transform goal = null;
    [SerializeField] private float goalSuccessDistance = 1f;

    [SerializeField] private NavMeshAgent agent;
    private PersonData info;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        info = GetComponent<PersonData>();
    }

    private void Start()
    {
        migrationPoints.Clear();
        //Migrate();
    }

    public void SetGoal(GameObject _goal)
    {
        goal = _goal.transform;
        agent.destination = goal.position;
    }

    public void Migrate()
    {
        // if person can no longer to afford to stay
        if(info.salary < 100 /*cityObj.GetComponent<CityData>().cityDataByYear*/)
        {
            // check against each hosue type x 4

            // loop through each house type
            foreach (var suburb in cityObj.GetComponent<City>().suburbs)
            {
                // if house is within price range
                if(info.salary > 10 /* suburb.cost */)
                {
                    // migrate to property
                    SetGoal(suburb);
                }
            }
        }
    }

    void Update()
    {
        /*if (Vector3.Distance(agent.transform.position, goal.position) <= goalSuccessDistance)
        {
            // Destroy(this.gameObject);
        }*/
    }
}
