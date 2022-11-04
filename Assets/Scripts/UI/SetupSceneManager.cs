using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SetupSceneManager : MonoBehaviour
{
    public static SetupSceneManager ssmInstance;
    public TMP_InputField inputField;

    public string max_population;


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
        max_population = inputField.text;
        SceneManager.LoadSceneAsync("MajorCities");

    }
    
}
