using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace Systems
{
    /// <summary>
    /// System to spawn obstacles
    /// </summary>
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnObstaclesSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BattleArenaProperties>();
        }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            // disable update loop to stop system in the next frame
            state.Enabled = false;
            // cache BattleArenaProperties component
            var battleArenaEntity = SystemAPI.GetSingletonEntity<BattleArenaProperties>();
            // cache BattleArenaAspect
            var battleArena = SystemAPI.GetAspect<BattleArenaAspect>(battleArenaEntity);
            // initialize entity Command buffer
            var entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            for (int i = 0; i <= battleArena.NumberOfObstaclesToSpawn; i++)
            {
                    // instanciate prefabs on main thread using entity command buffer 
                    var newObstacle = entityCommandBuffer.Instantiate(battleArena.ObstaclePrefab);
                    // set random position for new obstacle  
                    var newBattleArenaTransform = battleArena.GetRandomObstacleTransform();
                    // set new position to prefabs
                    entityCommandBuffer.SetComponent(newObstacle, newBattleArenaTransform);
            }
            // run command on main thread
            entityCommandBuffer.Playback(state.EntityManager);
        }

        
    }
}