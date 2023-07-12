using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ComponentsAndTags
{
    public readonly partial struct BattleArenaAspect : IAspect
    {
        // To get entity that has this aspect attached to it
        public readonly Entity Entity;
        // Read only access to local transform
        private readonly RefRO<LocalTransform> _transform;
        // Saving local transform's value 
        private LocalTransform Transform => _transform.ValueRO;
        // Getting write access to random to generate random number
        private readonly RefRW<BattleArenaRandom> _battleArenaRandom;
        // Getting write access to BattleArena Properties
        private readonly RefRW<BattleArenaProperties> _battleArenaProperties;
        // Getting Number of obstacles to spawn
        public int NumberOfObstaclesToSpawn => _battleArenaProperties.ValueRO.NumberOfObstaclesToSpawn;
        
        // Obstacle prefabs
        public Entity ObstaclePrefab => _battleArenaProperties.ValueRO.ObstaclePrefab;
        // Player Troops Prefab
        public Entity PlayerTroopPrefab => _battleArenaProperties.ValueRO.PlayerTroopPrefab;
        public LocalTransform GetRandomObstacleTransform()
        {
            return new LocalTransform
            {
                Position = GetRandomPosition(),
                Rotation = quaternion.identity,
                Scale = 1
            };
        }

        private float3 GetRandomPosition()
        {
            float3 randomPosition;
            randomPosition = _battleArenaRandom.ValueRW.Value.NextFloat3(MinCorner, MaxCorner);
            return randomPosition;
        }
        
        private float3 HalfDimension => new ()
        {
            x = _battleArenaProperties.ValueRO.FieldDimensions.x / 2,
            
            y = 0,
            z = _battleArenaProperties.ValueRO.FieldDimensions.y / 2
        };

        private float3 MinCorner => Transform.Position - HalfDimension;
        private float3 MaxCorner => Transform.Position + HalfDimension;
    }
} 