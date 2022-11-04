using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainSceneManager : MonoBehaviour
{
    public TextMeshProUGUI display_max_population;

    public void Awake()
    {
        display_max_population.text = SetupSceneManager.ssmInstance.max_population;

    }
}
