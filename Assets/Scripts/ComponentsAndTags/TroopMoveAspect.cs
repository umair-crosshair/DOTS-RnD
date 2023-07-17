using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ComponentsAndTags
{
    public readonly partial struct TroopMoveAspect : IAspect
    {
        public readonly Entity Entity;
        private readonly RefRW<LocalTransform> _transform;
        //private LocalTransform Transform => _transform.ValueRW;
        private readonly RefRW<TroopProperties> _troopProperties;

        public void Move(float2 inputValue, float DeltaTime)
        {
            _transform.ValueRW.Position.xz += inputValue * DeltaTime;
        }
    }
}