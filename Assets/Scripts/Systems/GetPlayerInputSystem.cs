using ComponentsAndTags;
using Unity.Entities;
using UnityEngine;

namespace Systems
{
    /// <summary>
    /// System to read player input
    /// </summary>

    // update current system in InitializationSystemGroup
    [UpdateInGroup(typeof(InitializationSystemGroup), OrderLast = true)]


    public partial class GetPlayerInputSystem : SystemBase
    {
        private TroopControls troopControls;
        private Entity entity;

        protected override void OnCreate()
        {
            RequireForUpdate<TroopMoveInput>();
            troopControls = new TroopControls();
        }

        protected override void OnStartRunning()
        {
            troopControls.Enable();
            entity = SystemAPI.GetSingletonEntity<BattleArenaProperties>();
        }

        protected override void OnStopRunning()
        {
            troopControls.Disable();
            entity = Entity.Null;
        }

        protected override void OnUpdate()
        {
            // each frame get input value from troopControls class and assign to the TroopMoveInput component
            var currentMoveInput = troopControls.troopactionmap.troopmovement.ReadValue<Vector2>();
            SystemAPI.SetSingleton(new TroopMoveInput{ InputValue = currentMoveInput });
        }
    }
}