using System;
using Unity.Entities;
using UnityEngine;

namespace ComponentsAndTags
{
    public partial class StartSimulationSystem : SystemBase
    {
        public Action OnStartSimulation;
        public bool IsAllowSpawning = false;
        public int NumberOfTroopsPerJob;
        public int MaxEntitiesCount;

        protected override void OnUpdate()
        {
            var entityCommandBuffer = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();
            var battleArenaEntity = SystemAPI.GetSingletonEntity<BattleArenaProperties>();
            var battleArenaAspect = SystemAPI.GetAspect<BattleArenaAspect>(battleArenaEntity);
            battleArenaAspect.AllowSpawning = IsAllowSpawning;
            battleArenaAspect.NumberOfTroopsPerJob = NumberOfTroopsPerJob;
            battleArenaAspect.MaxEntitesCount = MaxEntitiesCount;
            
            OnStartSimulation?.Invoke();
        }
    }
}