using ComponentsAndTags;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

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
            troopControls.troopactionmap.KeyPresses.performed += StartSpawnActionPressed;
            entity = SystemAPI.GetSingletonEntity<BattleArenaProperties>();
        }

        private void StartSpawnActionPressed(InputAction.CallbackContext obj)
        {
            if (SystemAPI.Exists(entity)) return;
            SystemAPI.SetComponentEnabled<SpawnBehaviourTag>(entity, true);
        }

        protected override void OnStopRunning()
        {
            troopControls.Disable();
            troopControls.troopactionmap.KeyPresses.performed -= StartSpawnActionPressed;
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