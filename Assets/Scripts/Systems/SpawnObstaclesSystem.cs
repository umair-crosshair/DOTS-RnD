using ComponentsAndTags;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

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
            for (int i = 0; i >= battleArena.NumberOfObstaclesToSpawn; i++)
            {
                entityCommandBuffer.Instantiate(battleArena.ObstaclePrefab);
            }
            entityCommandBuffer.Playback(state.EntityManager);
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}