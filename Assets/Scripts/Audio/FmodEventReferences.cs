using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Audio/EventReferences", fileName = "New Event Reference Sheet")]
public class FmodEventReferences : ScriptableObject
{
    [Header("UI")]

    [SerializeField] private string citySelectedEventName = null;
    public FMOD.Studio.EventInstance citySelectedInstance;

    [SerializeField] private string personSelectedEventName = null;
    public FMOD.Studio.EventInstance personSelectedInstance;

    [SerializeField] private string setUpSceneEnterEventName = null;
    public FMOD.Studio.EventInstance setUpSceneEnterInstance;

    [SerializeField] private string simulatePressedEventName = null;
    public FMOD.Studio.EventInstance simulatePressedInstance;

    [SerializeField] private string sliderMovedEventName = null;
    public FMOD.Studio.EventInstance sliderMovedInstance;




    [Header("Ambience")]
    [SerializeField] private string cityLoopEventName = null;
    public FMOD.Studio.EventInstance cityLoopInstance;



    public void CitySelectedInstance()
    {
        citySelectedInstance = FMODUnity.RuntimeManager.CreateInstance("Event:/" + citySelectedEventName);

    }

    public void PersonSelectedInstance()
    {
        personSelectedInstance = FMODUnity.RuntimeManager.CreateInstance("Event:/" + personSelectedEventName);

    }

    public void SetUpSceneEnterInstance()
    {
        setUpSceneEnterInstance = FMODUnity.RuntimeManager.CreateInstance("Event:/" + setUpSceneEnterEventName);

    }

    public void SimulatePressedInstance()
    {
        simulatePressedInstance = FMODUnity.RuntimeManager.CreateInstance("Event:/" + simulatePressedEventName);

    }

    public void SliderMovedInstance()
    {
        sliderMovedInstance = FMODUnity.RuntimeManager.CreateInstance("Event:/" + sliderMovedEventName);

    }

    public void CityLoop()
    {
        cityLoopInstance = FMODUnity.RuntimeManager.CreateInstance("Event:/" + cityLoopEventName);

    }
}
