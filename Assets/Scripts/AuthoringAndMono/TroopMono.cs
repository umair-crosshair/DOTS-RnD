using ComponentsAndTags;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace AuthoringAndMono
{
    /// <summary>
    /// Mono behaviour class that assigns data to the TroopMoveInput and TroopMoveSpeed struct.
    /// </summary>
    public class TroopMono : MonoBehaviour
    {
        public readonly Entity entity;
        public LocalTransform _LocalTransform;
    }

    public class TroopBaker : Baker<TroopMono>
    {

        public override void Bake(TroopMono authoring)
        {
            AddComponent(new TroopProperties { TroopTransform = authoring._LocalTransform } );
        }
    }
}