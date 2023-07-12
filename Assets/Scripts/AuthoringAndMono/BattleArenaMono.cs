using ComponentsAndTags;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace AuthoringAndMono
{
    public class BattleArenaMono : MonoBehaviour
    {
        // battle arena parameters
        public float2 FieldDimensions;
        public int NumberOfObstaclesToSpawn;
        // obstacle prefabs
        public GameObject ObstaclePrefab;
        // random values
        public uint RandomSeed;
        // troop prefabs
        public GameObject PlayerTroopPrefab;
    }

    public class BattleArenaBaker : Baker<BattleArenaMono>
    {
        public override void Bake(BattleArenaMono authoring)
        {
            var battleArenaEntity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(battleArenaEntity, 
                    new BattleArenaProperties
                    {
                        FieldDimensions = authoring.FieldDimensions,
                        NumberOfObstaclesToSpawn = authoring.NumberOfObstaclesToSpawn,
                        ObstaclePrefab = GetEntity(authoring.ObstaclePrefab, TransformUsageFlags.Dynamic),
                        PlayerTroopPrefab = GetEntity(authoring.PlayerTroopPrefab, TransformUsageFlags.Dynamic)
                    }
                );
            AddComponent(battleArenaEntity, 
                    new BattleArenaRandom
                    {
                        Value = Random.CreateFromIndex(authoring.RandomSeed)
                    }    
                );
        }
    }
}