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
        Debug.Log("yooo");
            yearSlider.value = yearSlider.value + 1;

            

           
        
    }

    public void StartSimulation()
    {
        yearSlider.value = 2010;
        
        InvokeRepeating("Timer", 5.0f, 5.0f);
       
    }
    public void ResetScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
