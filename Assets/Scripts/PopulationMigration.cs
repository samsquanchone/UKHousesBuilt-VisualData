
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationMigration : MonoBehaviour
{
    public List<GameObject> migrationPoints = new List<GameObject>();

    [SerializeField] private Transform goal = null;
    [SerializeField] private float goalSuccessDistance = 1f;

    [SerializeField] private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        //Migrate();
    }

    public void Migrate()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        goal = migrationPoints[Random.Range(0, migrationPoints.Count)].transform;
        agent.destination = goal.position;
    }

    void Update()
    {

        /*if (Vector3.Distance(agent.transform.position, goal.position) <= goalSuccessDistance)
        {
            // Destroy(this.gameObject);
        }*/
    }
}
