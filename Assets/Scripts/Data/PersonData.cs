using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonData : MonoBehaviour
{
    public float salary;
    [SerializeField] private float minSalary;
    [SerializeField] private float maxSalary;
    [SerializeField] private string[] names;
    public string name;
    // Start is called before the first frame update
    void Start()
    {
        name = names[Random.Range(0, names.Length)];
        salary = Random.Range(minSalary, maxSalary);
    }

}
