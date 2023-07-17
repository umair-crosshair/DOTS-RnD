using ComponentsAndTags;
using Unity.Entities;
using UnityEngine;

namespace TMG.InputSystemTutorial
{
    public class PlayerAuthoring : MonoBehaviour
    {
        public float MoveSpeed;
    }

    public class PlayerAuthoringBaker : Baker<PlayerAuthoring>
    {
        public override void Bake(PlayerAuthoring authoring)
        {
            var playerEntity = GetEntity(TransformUsageFlags.Dynamic);
            
            AddComponent<TroopMoveInput>(playerEntity);
            
            AddComponent(playerEntity, new TroopMoveSpeed()
            {
                Value = authoring.MoveSpeed
            });
        }
    }
}