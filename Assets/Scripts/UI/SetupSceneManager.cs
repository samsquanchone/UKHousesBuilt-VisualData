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
        if (float.TryParse(input_min_salary.text, out float min_salary_int) != true)
        {

            return false;
        }
        else
        {
            min_salary_int = Mathf.Clamp(min_salary_int, 30000, 40000);
            input_min_salary.text = min_salary_int.ToString();
        }

        if (float.TryParse(input_max_salary.text, out float max_salary_int) != true)
        {
            return false;
        }
        else 
        {
            max_salary_int = Mathf.Clamp(max_salary_int, 100000, 1000000);
            input_max_salary.text = max_salary_int.ToString();
        }
       
        /*if (float.TryParse(input_max_population.text, out float max_population_int) != true)
        {
            return false;
        }*/

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
            AudioEventSystem.TriggerEvent("SetUpSceneEnterSFX", null);
            max_population = input_max_population.text;
            min_salary = input_min_salary.text;
            max_salary = input_max_salary.text;

            SceneManager.LoadSceneAsync("MajorCities");
        }
    }
    
}
