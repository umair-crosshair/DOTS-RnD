using System;
using AuthoringAndMono;
using ComponentsAndTags;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    /// <summary>
    /// MonoBehaviour to control the starting of spawn System.
    /// This scripts gets UI elements from UIManager and interacts with the StartSimulationSystem.
    /// </summary>
    public class TroopSpawnController : MonoBehaviour
    {
        // maximum entities which can be spawned
        private int maxEntitiesCount;
        // maximum entities which 1 job can spawn at a time
        private int numberOfTroopsPerJob;

        private void OnEnable()
        {
            // caching the entity manager.
            var startSimulationSystem = World.DefaultGameObjectInjectionWorld
                .GetExistingSystemManaged<StartSimulationSystem>();
            // Disabling the Start Simulation System.
            startSimulationSystem.Enabled = false;
            // Subscribing to the event fired when simulation has just started.
            startSimulationSystem.OnStartSimulation += OnstartSimulation;
        }

        private void OnDisable()
        {
            // Checking if there is no entity manager in scene
            if (World.DefaultGameObjectInjectionWorld == null) return;
            // caching the entity manager.
            var startSimulationSystem = World.DefaultGameObjectInjectionWorld
                .GetExistingSystemManaged<StartSimulationSystem>();
            // Unsubscribing to the event fired when simulation has just started.
            startSimulationSystem.OnStartSimulation -= OnstartSimulation;
        }

        private void OnstartSimulation()
        {
            var startSimulationSystem = World.DefaultGameObjectInjectionWorld
                .GetExistingSystemManaged<StartSimulationSystem>();
            // Turning off the Start simulation starting screen.
            UIManager.Instance.StartSimulationScreen.SetActive(false);
            // Disabling the Start simulation system to avoid running it again the next frame
            startSimulationSystem.Enabled = false;
        }

        // Method to start the Simulation System and initialize it's properties
        public void StartSimulationSystem()
        {
            // caching the entity manager.
            var startSimulationSystem = World.DefaultGameObjectInjectionWorld
                .GetExistingSystemManaged<StartSimulationSystem>();

            // getting values from text input
            try
            {
                maxEntitiesCount = Convert.ToInt32(UIManager.Instance.EntitiesSpawnCount.text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // setting default values in case of a mistake in input
                this.maxEntitiesCount = 10000;
            }

            try
            {
                numberOfTroopsPerJob = Convert.ToInt32(UIManager.Instance.EntitiesPerJob.text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // setting default values in case of a mistake in input
                numberOfTroopsPerJob = 100;
            }

            // clamping values so that they remain within the range
            //maxEntitiesCount = ClampValue(maxEntitiesCount, 300000);
            
            numberOfTroopsPerJob = ClampValue(numberOfTroopsPerJob, 10000);
            // validating input
            ValidateSetInput(maxEntitiesCount, numberOfTroopsPerJob);
            
            ApplyInputValuesToSystem(startSimulationSystem, numberOfTroopsPerJob, maxEntitiesCount);
            startSimulationSystem.Enabled = true;
        }
        // method to clamp values
        private int ClampValue(int value, int maxValue)
        {
            if (value > maxValue)
            {
                value = maxValue;
            }

            return value;
        }
        // validating input values
        private void ValidateSetInput(int maxEntitiesCount, int numberOfTroopsPerJob)
        {
            
            int defaultValue = 1000;
            // setting value to default in case it's 0 or less
            if (maxEntitiesCount <= 0)
            {
                maxEntitiesCount = defaultValue;
            }
            // setting value to 1/10 of max entities in case it's 0 or less
            if (numberOfTroopsPerJob <= 0)
            {
                numberOfTroopsPerJob = maxEntitiesCount / 10;
            }
            // setting number of troops value to 1/10th of max entities in case it exceeds the max entities
            if (numberOfTroopsPerJob > maxEntitiesCount)
            {
                numberOfTroopsPerJob = defaultValue / 10;
                maxEntitiesCount = defaultValue;

            }
        }
        // applying values to Simulation System
        private void ApplyInputValuesToSystem(StartSimulationSystem startSimulationSystem, int numberOfTroopsPreJob,
            int maxEntitiesCount)
        {
            startSimulationSystem.MaxEntitiesCount = maxEntitiesCount;
            startSimulationSystem.NumberOfTroopsPerJob = numberOfTroopsPreJob;
            startSimulationSystem.IsAllowSpawning = true;
        }

    }
}
