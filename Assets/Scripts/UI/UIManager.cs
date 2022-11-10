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

    IEnumerator Timer()
    {
        if (yearSlider.value <= 2020)
        {
            yearSlider.value = yearSlider.value + 1;

            yield return new WaitForSeconds(5f);

            Timer();
        }
    }

    public void StartSimulation()
    {
        
    }
    public void ResetScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
