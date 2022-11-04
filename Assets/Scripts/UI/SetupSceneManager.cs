using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SetupSceneManager : MonoBehaviour
{
    public static SetupSceneManager ssmInstance;
    public TMP_InputField input_max_population;
    public TMP_InputField input_min_salary;
    public TMP_InputField input_max_salary;


    public string max_population;
    public string min_salary;
    public string max_salary;



    private void Awake()
    {
       
        if (ssmInstance != null)
        {
            Destroy(gameObject);
            return;
        }
       
        ssmInstance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetupDataInput()
    {
        max_population = input_max_population.text;
        min_salary = input_min_salary.text;
        max_salary = input_max_salary.text;
        

        SceneManager.LoadSceneAsync("MajorCities");

    }
    
}
