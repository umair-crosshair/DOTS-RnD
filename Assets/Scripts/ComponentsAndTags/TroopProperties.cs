using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace ComponentsAndTags
{
    public struct TroopProperties : IComponentData
    {
        public LocalTransform TroopTransform;
    }
}