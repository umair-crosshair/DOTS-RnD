using System.Numerics;
using ComponentsAndTags;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    [UpdateBefore(typeof(TransformSystemGroup))]
    public partial struct MoveTroopSystem : ISystem
    {

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            new MoveTroopJob
            {
                DeltaTime = deltaTime
            }.Schedule();
        }
    }
    public partial struct MoveTroopJob : IJobEntity
    {
        public float DeltaTime;
        [BurstCompile]
        private void Execute(ref LocalTransform localTransform, in TroopMoveInput moveInput, TroopMoveSpeed moveSpeed)
        {
            localTransform.Position.xz += moveInput.InputValue * moveSpeed.Value * DeltaTime;
        }
        
    }
}