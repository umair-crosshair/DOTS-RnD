using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace ComponentsAndTags
{
    /// <summary>
    /// Aspect containing troop movement properties
    /// </summary>
    public readonly partial struct TroopMoveAspect : IAspect
    {
        public readonly Entity Entity;
        private readonly RefRW<LocalTransform> _transform;
        //private LocalTransform Transform => _transform.ValueRW;
        private readonly RefRW<TroopProperties> _troopProperties;
        // function to move entities transform by input value
        public void Move(float2 inputValue, float DeltaTime)
        {
            _transform.ValueRW.Position.xz += inputValue * DeltaTime;
        }
    }
}