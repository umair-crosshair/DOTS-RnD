using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;

namespace Systems
{
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
            state.Enabled = false;
            var battleArenaEntity = SystemAPI.GetSingletonEntity<BattleArenaProperties>();
            var battleArena = SystemAPI.GetAspect<BattleArenaAspect>(battleArenaEntity);

            var entityCommandBuffer = new EntityCommandBuffer(Allocator.Temp);
            for (int i = 0; i <= battleArena.NumberOfObstaclesToSpawn; i++)
            {
                if ((i % 3) == 0)
                {
                    var newObstacle = entityCommandBuffer.Instantiate(battleArena.ObstaclePrefab);
                    var newBattleArenaTransform = battleArena.GetRandomObstacleTransform();
                    entityCommandBuffer.SetComponent(newObstacle, newBattleArenaTransform);
                }
                else if (i % 2 == 0)
                {
                    var newObstacle = entityCommandBuffer.Instantiate(battleArena.ObstaclePrefab2);
                    var newBattleArenaTransform = battleArena.GetRandomObstacleTransform();
                    entityCommandBuffer.SetComponent(newObstacle, newBattleArenaTransform);
                }
                else
                {
                    var newObstacle = entityCommandBuffer.Instantiate(battleArena.ObstaclePrefab3);
                    var newBattleArenaTransform = battleArena.GetRandomObstacleTransform();
                    entityCommandBuffer.SetComponent(newObstacle, newBattleArenaTransform);
                }
                
            }
            entityCommandBuffer.Playback(state.EntityManager);
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}