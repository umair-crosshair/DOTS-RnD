using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags
{
    public struct TroopMoveInput : IComponentData
    {
        public float2 InputValue;
    }

    public struct TroopMoveSpeed : IComponentData
    {
        public float2 Value;
    }
}