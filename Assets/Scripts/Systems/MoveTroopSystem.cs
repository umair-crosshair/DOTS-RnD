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
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<TroopMoveInput>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;
            var troopMoveInput = SystemAPI.GetSingleton<TroopMoveInput>();
            new MoveTroopJob()
            {
                DeltaTime = deltaTime,
                inputValue = troopMoveInput.InputValue
            }.ScheduleParallel();
        }
        }
        [BurstCompile]
    public partial struct MoveTroopJob : IJobEntity
    {
        public float DeltaTime;
        public float2 inputValue;
        
        [BurstCompile]
            private void Execute(TroopMoveAspect troop , [EntityIndexInQuery] int sortKey)
            {
                
                troop.Move(inputValue, DeltaTime);
            }
        }
        
    }
