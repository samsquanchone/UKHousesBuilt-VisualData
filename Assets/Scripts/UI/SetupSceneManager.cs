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

    private bool CheckValidDataInput()
    {
        if (int.TryParse(input_min_salary.text, out int min_salary_int) != true)
        {
            return false;
        }
        if (int.TryParse(input_max_salary.text, out int max_salary_int) != true)
        {
            return false;
        }
        if (int.TryParse(input_max_population.text, out int max_population_int) != true)
        {
            return false;
        }

        return true;
    }

    public void SetupDataInput()
    {
        if (CheckValidDataInput() == false)
        {
            Debug.Log("error with data input");
        }
        else
        {
            max_population = input_max_population.text;
            min_salary = input_min_salary.text;
            max_salary = input_max_salary.text;

            SceneManager.LoadSceneAsync("MajorCities");
        }
    }
    
}
