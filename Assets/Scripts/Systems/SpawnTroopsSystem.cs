using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
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
            new SpawnTroopsJob
            {
                TroopsToSpawn = battleArenaAspect.NumberOfTroopsPerJob,
                _entityCommandBuffer = entityCommandBuffer.CreateCommandBuffer(state.WorldUnmanaged)
            }.Schedule();
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
    [BurstCompile]
    public partial struct SpawnTroopsJob : IJobEntity
    {
        public int TroopsToSpawn;

        public EntityCommandBuffer _entityCommandBuffer;
        private void Execute(BattleArenaAspect battleArenaAspect)
        {
            for (int i = 0; i < TroopsToSpawn; i++)
            {
                _entityCommandBuffer.Instantiate(battleArenaAspect.PlayerTroopPrefab);
            }
        }
    }
}