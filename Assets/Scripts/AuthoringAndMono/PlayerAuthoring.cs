using ComponentsAndTags;
using Unity.Entities;
using UnityEngine;

namespace TMG.InputSystemTutorial
{
    /// <summary>
    /// Mono behaviour class that assigns data to the TroopMoveInput and TroopMoveSpeed struct.
    /// </summary>
    public class PlayerAuthoring : MonoBehaviour
    {
        // Troop Movement speed
        public float MoveSpeed;
    }
    /// <summary>
    /// Baker class to bake Player Authoring monobehaviour data into the PlayerMoveInput and PlayerMoveSpeed struct
    /// </summary>
    public class PlayerAuthoringBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            // Getting entity having the PlayerAuthoring component
            var playerEntity = GetEntity(TransformUsageFlags.Dynamic);
            // Adding TroopMoveInput component to the Entity
            AddComponent<TroopMoveInput>(playerEntity);
            // Adding TroopMoveSpeed component to the Entity
            AddComponent(playerEntity, new TroopMoveSpeed()
            {
                // maping PlayerAuthoring class random property to TroopMoveSpeed struct
                Value = authoring.MoveSpeed
            });
        }
    }
}