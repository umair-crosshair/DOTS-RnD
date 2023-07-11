using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags
{
    public struct BattleArenaProperties : IComponentData
    {
        public float2 FieldDimensions;
        public int NumberOfObstaclesToSpawn;
        public Entity ObstaclePrefab;
        public Entity ObstaclePrefab2;
        public Entity ObstaclePrefab3;
        public Random Value;
    }
}