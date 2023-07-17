using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ComponentsAndTags
{
    public readonly partial struct TroopMoveAspect : IAspect
    {
        public readonly Entity Entity;
        private readonly RefRW<LocalTransform> _transform;
        private LocalTransform Transform => _transform.ValueRO;

        public void Move(float2 inputValue)
        {
            _transform.ValueRW.Position.xz += inputValue;
        }

    }
}