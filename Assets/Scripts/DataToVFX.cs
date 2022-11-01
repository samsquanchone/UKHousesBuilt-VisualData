using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DataToVFX : MonoBehaviour
{
    public static DataToVFX instance => m_Instance;
    private static DataToVFX m_Instance;
    private VisualEffect[] vfxs;
    private int arraySize = 4;

    GameObject[] objects;
    void Awake()
    {
        m_Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

        objects = GameObject.FindGameObjectsWithTag("VFX");
        

  
       
    }

    //Pass array of values from year selected by UI (DataManager script)
    public void SetParticleAmount(float[] numberOfHouses)
    {


        for (int i = 0; i < numberOfHouses.Length; i++)
        { //Getting all objects that are tagged with VFX and storing them in a gameobject array
             objects[i].GetComponent<VisualEffect>().SendEvent("Stop");
            //    vfx.SetFloat("NumberOfHouses", 0); //Sets a property in the VFX graph that sets the number of particles to spawn (number of houses built for year)
            objects[i].GetComponent<VisualEffect>().SetFloat("NumberOfHouses", numberOfHouses[i]);
            objects[i].GetComponent<VisualEffect>().SendEvent("Spawn");

        }
        
       

    }
 

}
