using System;
using ComponentsAndTags;
using Unity.Entities;

namespace Systems
{
    public partial class StartSimulationSystem : SystemBase
    {
        public Action OnStartSimulation;
        public bool IsAllowSpawning;
        public int NumberOfTroopsPerJob;
        public int MaxEntitiesCount;

        protected override void OnUpdate()
        {
            var battleArenaEntity = SystemAPI.GetSingletonEntity<BattleArenaProperties>();
            var battleArenaAspect = SystemAPI.GetAspect<BattleArenaAspect>(battleArenaEntity);
            battleArenaAspect.AllowSpawning = IsAllowSpawning;
            battleArenaAspect.NumberOfTroopsPerJob = NumberOfTroopsPerJob;
            battleArenaAspect.MaxEntitesCount = MaxEntitiesCount;
            OnStartSimulation?.Invoke();
        }
    }
}