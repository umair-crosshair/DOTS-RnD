using Unity.Entities;
using Unity.Transforms;

namespace ComponentsAndTags
{
    /// <summary>
    /// component holding Troops transform
    /// </summary>
    public struct TroopProperties : IComponentData
    {
        public LocalTransform TroopTransform;
    }
}