using Unity.Entities;
using Unity.Mathematics;

namespace ComponentsAndTags
{
    /// <summary>
    /// Component containing a random value
    /// </summary>
    public struct BattleArenaRandom : IComponentData
    {
        public Random Value;
    }
}