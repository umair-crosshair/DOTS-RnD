using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags
{
    public struct BattleArenaProperties : IComponentData
    {
        // battle arena parameters
        public float2 FieldDimensions;
        public int NumberOfObstaclesToSpawn;
        // obstacle prefab
        public Entity ObstaclePrefab;
        // random values
        public Random Value;
        // troop prefabs
        public Entity PlayerTroopPrefab;
    }
}