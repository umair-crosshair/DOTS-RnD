using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags
{
    /// <summary>
    /// Properties class containing properties of the battle arena component
    /// </summary>
    public struct BattleArenaProperties : IComponentData
    {
        // battle arena parameters
        public float2 FieldDimensions;
        // number of obstacles which can spawn
        public int NumberOfObstaclesToSpawn;
        // obstacle prefab
        public Entity ObstaclePrefab;
        // random values
        public Random Value;
        // troop prefabs
        public Entity PlayerTroopPrefab;
        // number of prefabs to spawn in one go per job
        public int NumberOfTroopsPerJob;
        // entities which have been spawned
        public int EntitiesSpawnedCount;
        // entities which can be spawned
        public int MaxEntitesCount;
    }
}