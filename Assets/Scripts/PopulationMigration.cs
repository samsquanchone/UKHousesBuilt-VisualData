
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

    //[SerializeField] private PopulationSpawn pop;

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

    public void Migrate(int year)
    {
        float[] salaryPerHouseTypes;

        if (DataManager.instance.salariesPerCity[PopulationSpawn.Instance.cities.IndexOf(cityObj)].TryGetValue(year, out salaryPerHouseTypes))
        {
            for (int j = salaryPerHouseTypes.Length - 1; j >= 0; --j)
            {
                if (this.GetComponent<PersonData>().salary > salaryPerHouseTypes[j])
                {
                    City city = cityObj.GetComponent<City>();
                    this.GetComponent<PopulationMigration>().SetGoal(city.suburbs[j]);
                    //housing = true;
                    break;
                }
            }
        }

        /*if (!housing)
        {
            Debug.Log("person: " + i + " cannot afford housing");
            person.GetComponent<PopulationMigration>().SetGoal(spawnObj);
        }*/
    }

    void Update()
    {
        /*if (Vector3.Distance(agent.transform.position, goal.position) <= goalSuccessDistance)
        {
            // Destroy(this.gameObject);
        }*/
    }
}
