using ComponentsAndTags;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Systems
{
    /// <summary>
    /// System to move troop entities according to input
    /// </summary>

    // update current system after TransformSystemGroup
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
            // get delta time value from systemAPI
            var deltaTime = SystemAPI.Time.DeltaTime;
            // get input value from TroopMoveInput component
            var troopMoveInput = SystemAPI.GetSingleton<TroopMoveInput>();
            // schedule parallel job to move troops and assign job properties
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
        
        // execute method to execute job, must have a sort key to run in parallel
        [BurstCompile]
            private void Execute(TroopMoveAspect troop , [EntityIndexInQuery] int sortKey)
            {
                // call Move action in aspect on each entity to move it indivisually
                troop.Move(inputValue, DeltaTime);
            }
        }
        
    }
