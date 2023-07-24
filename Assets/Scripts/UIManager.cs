using System;
using ComponentsAndTags;
using TMPro;
using Unity.Entities;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Start simulation screen")]
    public GameObject StartSimulationScreen;
    public TMP_InputField EntitiesPerJob;
    public TMP_InputField EntitiesSpawnCount;

    private void OnEnable()
    {
        var startSimulationSystem = World.DefaultGameObjectInjectionWorld
            .GetExistingSystemManaged<StartSimulationSystem>();
        startSimulationSystem.Enabled = false;
        startSimulationSystem.OnStartSimulation += OnstartSimulation;
    }

    private void OnDisable()
    {
        if (World.DefaultGameObjectInjectionWorld == null) return;
        var startSimulationSystem = World.DefaultGameObjectInjectionWorld
            .GetExistingSystemManaged<StartSimulationSystem>();
        startSimulationSystem.OnStartSimulation -= OnstartSimulation;
    }

    private void OnstartSimulation()
    {
        StartSimulationScreen.SetActive(false);
    }

    public void StartSimulationSystem()
    {
        var startSimulationSystem = World.DefaultGameObjectInjectionWorld
            .GetExistingSystemManaged<StartSimulationSystem>();
        startSimulationSystem.IsAllowSpawning = true;
        startSimulationSystem.MaxEntitiesCount = Convert.ToInt32(EntitiesSpawnCount.text);
        startSimulationSystem.NumberOfTroopsPerJob = Convert.ToInt32(EntitiesPerJob.text);
        startSimulationSystem.Enabled = true;
        StartSimulationScreen.SetActive(false);
        
    }

}