using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Slider yearSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Timer()
    {
       
        yearSlider.value = yearSlider.value + 1;

    }

    public void StartSimulation()
    {
        AudioEventSystem.TriggerEvent("SimulatePressedSFX", null);
        yearSlider.value = 2010;

        CancelInvoke();
        InvokeRepeating("Timer", 5.0f, 5.0f);
       
    }

    public void PauseSmiulation()
    {
        CancelInvoke();
    }
    public void ResetScene()
    {
        AudioEventSystem.TriggerEvent("StopCityLoop", null);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
