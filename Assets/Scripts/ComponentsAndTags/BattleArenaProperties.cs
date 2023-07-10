using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags
{
    public struct BattleArenaProperties : IComponentData
    {
        public float2 FieldDimensions;
        public int NumberOfObstaclesToSpawn;
        public Entity ObstaclePrefab;
        public Random Value;
    }
}