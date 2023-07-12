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
            //state.Enabled = false;
            // getting battle arena entity
            var BattleArenaEntity = SystemAPI.GetSingletonEntity<BattleArenaProperties>();
            // getting battle arena aspect for the above entity
            var BattleArenaAspect = SystemAPI.GetAspect<BattleArenaAspect>(BattleArenaEntity);
            // initializing Entity command buffer to execute commands
            var entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            // instantiating player troop
            var newTroop = entityCommandBuffer.Instantiate(BattleArenaAspect.PlayerTroopPrefab);
            // setting random position of troop
            var newTroopRandomTransform = BattleArenaAspect.GetRandomObstacleTransform();
            entityCommandBuffer.SetComponent(newTroop, newTroopRandomTransform);
            entityCommandBuffer.Playback(state.EntityManager);   
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {
        }
    }
}