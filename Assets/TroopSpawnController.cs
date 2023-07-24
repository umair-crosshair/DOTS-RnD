using System;
using ComponentsAndTags;
using Unity.Entities;
using UnityEngine;

public class TroopSpawnController : MonoBehaviour
{
    private int maxEntitiesCount;
    private int numberOfTroopsPerJob;
    
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
        var startSimulationSystem = World.DefaultGameObjectInjectionWorld
            .GetExistingSystemManaged<StartSimulationSystem>();
        UIManager.Instance.StartSimulationScreen.SetActive(false);
        startSimulationSystem.Enabled = false;
    }
    
    public void StartSimulationSystem()
    {
        var startSimulationSystem = World.DefaultGameObjectInjectionWorld
            .GetExistingSystemManaged<StartSimulationSystem>();
        

        try
        {
            maxEntitiesCount = Convert.ToInt32(UIManager.Instance.EntitiesSpawnCount.text);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            this.maxEntitiesCount = 10000;
        }

        try
        {
            numberOfTroopsPerJob = Convert.ToInt32(UIManager.Instance.EntitiesPerJob.text);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            numberOfTroopsPerJob = 100;
        }
        
        
        
        maxEntitiesCount = ClampValue(maxEntitiesCount, 200000);
        numberOfTroopsPerJob = ClampValue(numberOfTroopsPerJob, 5000);
        ValidateSetInput(maxEntitiesCount, numberOfTroopsPerJob);
        ApplyInputValuesToSystem(startSimulationSystem, numberOfTroopsPerJob, maxEntitiesCount);
        startSimulationSystem.Enabled = true;
    }

    private int ClampValue(int value, int maxValue)
    {
        if (value > maxValue)
        {
            value = maxValue;
        }

        return value;
    }
    private void ValidateSetInput(int maxEntitiesCount, int numberOfTroopsPerJob)
    {
        int defaultValue = 1000;
        if (maxEntitiesCount <= 0)
        {
            maxEntitiesCount = defaultValue;
        }
        if (numberOfTroopsPerJob <= 0)
        {
            numberOfTroopsPerJob = maxEntitiesCount/10;
        }
        if (numberOfTroopsPerJob > maxEntitiesCount)
        {
            numberOfTroopsPerJob = defaultValue/10;
            maxEntitiesCount = defaultValue;

        }
    }

    private void ApplyInputValuesToSystem(StartSimulationSystem startSimulationSystem, int numberOfTroopsPreJob, int maxEntitiesCount)
    {
        startSimulationSystem.MaxEntitiesCount = maxEntitiesCount;
        startSimulationSystem.NumberOfTroopsPerJob = numberOfTroopsPreJob;
        startSimulationSystem.IsAllowSpawning = true;
    }

}
