using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonData : MonoBehaviour
{
    public float salary;
    [SerializeField] private string[] names;
    public string personName;
    // Start is called before the first frame update
    void Awake()
    {
        personName = names[Random.Range(0, names.Length)];
        salary = Random.Range((float)MainSceneManager.instance.minSalary, (float)MainSceneManager.instance.maxSalary);
    }

}
