using 
    ComponentsAndTags;
using Unity.Burst;
using Unity.Entities;

namespace Systems
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnTroopsSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BattleArenaProperties>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            
            var entityCommandBuffer = SystemAPI.GetSingleton<BeginInitializationEntityCommandBufferSystem.Singleton>();
            var battleArenaEntity = SystemAPI.GetSingletonEntity<BattleArenaProperties>();
            var battleArenaAspect = SystemAPI.GetAspect<BattleArenaAspect>(battleArenaEntity);
                        
            battleArenaAspect.EntitiesSpawnedCount += battleArenaAspect.NumberOfTroopsPerJob;
            if (battleArenaAspect.EntitiesSpawnedCount > battleArenaAspect.MaxEntitesCount)
            {
                state.Enabled = false;
                return;
            }
            new SpawnTroopsJob
            {
                TroopsToSpawn = battleArenaAspect.NumberOfTroopsPerJob,
                _entityCommandBuffer = entityCommandBuffer.CreateCommandBuffer(state.WorldUnmanaged).AsParallelWriter()
            }.ScheduleParallel();
        }
    }
    [BurstCompile]
    public partial struct SpawnTroopsJob : IJobEntity
    {
        public int TroopsToSpawn;
        
        public EntityCommandBuffer.ParallelWriter _entityCommandBuffer;
        private void Execute(BattleArenaAspect battleArenaAspect, [EntityIndexInQuery] int sortKey)
        {
            for (int i = 0; i < TroopsToSpawn; i++)
            {
                var tempTroop = _entityCommandBuffer.Instantiate(sortKey, battleArenaAspect.PlayerTroopPrefab);

                var newBattleArenaTransform = battleArenaAspect.GetRandomObstacleTransform();
                _entityCommandBuffer.SetComponent(sortKey, tempTroop, newBattleArenaTransform);
            }
        }
    }
}