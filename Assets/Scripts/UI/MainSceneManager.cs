using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MainSceneManager : MonoBehaviour
{
    public static MainSceneManager instance => m_instance;
    private static MainSceneManager m_instance;
    public TextMeshProUGUI display_max_population;
    public float minSalary;
    public float maxSalary;

    public void Awake()
    {
        m_instance = this;
        display_max_population.text = SetupSceneManager.ssmInstance.max_population;
        minSalary = float.Parse(SetupSceneManager.ssmInstance.min_salary);
        maxSalary = float.Parse(SetupSceneManager.ssmInstance.max_salary);
        Debug.Log("MinSal: " +  minSalary + "MaxSal: " + maxSalary);
    }
}
