using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags
{
    /// <summary>
    /// component holding player input value
    /// </summary>
    public struct TroopMoveInput : IComponentData
    {
        public float2 InputValue;
    }
    /// <summary>
    /// component holding player movement speed value
    /// </summary>
    public struct TroopMoveSpeed : IComponentData
    {
        public float2 Value;
    }
}