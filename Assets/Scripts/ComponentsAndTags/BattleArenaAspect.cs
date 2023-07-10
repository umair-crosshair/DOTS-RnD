using Unity.Entities;
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
        
        // Obstacle prefab
        public Entity ObstaclePrefab => _battleArenaProperties.ValueRO.ObstaclePrefab;
    }
} 