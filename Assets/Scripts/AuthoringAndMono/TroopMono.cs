using ComponentsAndTags;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace AuthoringAndMono
{
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