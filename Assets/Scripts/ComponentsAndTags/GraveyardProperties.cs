using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags
{
    public struct GraveyardProperties : IComponentData
    {
        public float2 FieldDimensions;
        public int NumberOfTombstonesToSpawn;
        public Entity TombstonePrefab;
    }
}
