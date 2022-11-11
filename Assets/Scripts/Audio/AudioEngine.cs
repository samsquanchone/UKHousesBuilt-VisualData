using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AudioEngine : MonoBehaviour
{
    public FmodEventReferences fmodEventReferences; // Use this to supply desired set of fmod event references


    void OnEnable()
    {
        AudioEventSystem.StartListening("CitySelectedSFX", CitySelectedSFX);
        AudioEventSystem.StartListening("PersonSelectedSFX", PersonSelectedSFX);
        AudioEventSystem.StartListening("SetUpSceneEnterSFX", SetUpSceneEnterSFX);
        AudioEventSystem.StartListening("SimulatePressedSFX", SimulatePressedSFX);
        AudioEventSystem.StartListening("SliderMovedSFX", SliderMovedSFX);
        AudioEventSystem.StartListening("StartCityLoop", StartCityLoop);
        AudioEventSystem.StartListening("StopCityLoop", StopCityLoop);
        
    }

    void OnDisable()
    {
        AudioEventSystem.StopListening("CitySelectedSFX", CitySelectedSFX);
        AudioEventSystem.StopListening("PersonSelectedSFX", PersonSelectedSFX);
        AudioEventSystem.StopListening("SetUpSceneEnterSFX", SetUpSceneEnterSFX);
        AudioEventSystem.StopListening("SimulatePressedSFX", SimulatePressedSFX);
        AudioEventSystem.StopListening("SliderMovedSFX", SliderMovedSFX);
        AudioEventSystem.StopListening("StartCityLoop", StartCityLoop);
        AudioEventSystem.StopListening("StopCityLoop", StopCityLoop);
    }


    public void CitySelectedSFX(GameObject objToAttachTo)
    {
        fmodEventReferences.CitySelectedInstance();
        fmodEventReferences.citySelectedInstance.start();
        fmodEventReferences.citySelectedInstance.release();

    }

    public void PersonSelectedSFX(GameObject objToAttachTo)
    {
        fmodEventReferences.PersonSelectedInstance();
        fmodEventReferences.personSelectedInstance.start();
        fmodEventReferences.personSelectedInstance.release();

    }

    public void SetUpSceneEnterSFX(GameObject objToAttachTo)
    {
        fmodEventReferences.SetUpSceneEnterInstance();
        fmodEventReferences.setUpSceneEnterInstance.start();
        fmodEventReferences.setUpSceneEnterInstance.release();

    }

    public void SimulatePressedSFX(GameObject objToAttachTo)
    {
        fmodEventReferences.SimulatePressedInstance();
        fmodEventReferences.simulatePressedInstance.start();
        fmodEventReferences.simulatePressedInstance.release();

    }

    public void SliderMovedSFX(GameObject objToAttachTo)
    {
        fmodEventReferences.SliderMovedInstance();
        fmodEventReferences.sliderMovedInstance.start();
        fmodEventReferences.sliderMovedInstance.release();

    }

    public void StartCityLoop(GameObject objToAttachTo)
    {
        fmodEventReferences.CityLoop();
        fmodEventReferences.cityLoopInstance.start();

    }

    public void StopCityLoop(GameObject objToAttachTo)
    {
        fmodEventReferences.cityLoopInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);//Stop loop
        fmodEventReferences.cityLoopInstance.release();
    }
}
