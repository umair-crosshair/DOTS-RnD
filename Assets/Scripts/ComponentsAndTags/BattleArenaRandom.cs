using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags
{
    public struct BattleArenaRandom : IComponentData
    {
        public Random Value;
    }
}