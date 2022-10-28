using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class DataToVFX : MonoBehaviour
{
    private VisualEffect[] vfxs;
    private int arraySize = 4;

    GameObject[] objects;
    // Start is called before the first frame update
    void Start()
    {

        objects = GameObject.FindGameObjectsWithTag("VFX");

  
       
    }

    public void SetParticleAmount(float numberOfHouses)
    {


        for (int i = 0; i <= arraySize; i++)
        { //Getting all objects that are tagged with VFX and storing them in a gameobject array
             objects[i].GetComponent<VisualEffect>().SendEvent("Stop");
            //    vfx.SetFloat("NumberOfHouses", 0); //Sets a property in the VFX graph that sets the number of particles to spawn (number of houses built for year)
            objects[i].GetComponent<VisualEffect>().SetFloat("NumberOfHouses", numberOfHouses);
            objects[i].GetComponent<VisualEffect>().SendEvent("Spawn");

        }
        
       

    }
  /*  public void SetParticleColor(float averageHousePrice)
    {
        if (averageHousePrice < 100) //Set particle color to green if house prices are below 250k
        {
            vfx.SetFloat("R", 0);
            vfx.SetFloat("G", 255);
            vfx.SetFloat("B", 0);
        }

        if (averageHousePrice >= 100 && averageHousePrice <= 500) //Set particle color to orange if house prices are above 250k but below 500k
        {
            vfx.SetFloat("R", 249);
            vfx.SetFloat("G", 191);
            vfx.SetFloat("B", 59);
        }

        else //Set particles to scarlet if houseprices are over £500k
        {
            vfx.SetFloat("R", 255);
            vfx.SetFloat("G", 0);
            vfx.SetFloat("B", 0);
        }
 */  //}
}
