using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags
{
    public struct BattleArenaProperties : IComponentData
    {
        // battle arena parameters
        public float2 FieldDimensions;
        public int NumberOfObstaclesToSpawn;
        // obstacle prefabs
        public Entity ObstaclePrefab;
        public Entity ObstaclePrefab2;
        public Entity ObstaclePrefab3;
        // random values
        public Random Value;
        // troop prefabs
        public Entity PlayerTroopPrefab;
    }
}