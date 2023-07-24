using ComponentsAndTags;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace AuthoringAndMono
{
    /// <summary>
    /// Mono behaviour class that represents the BattleArenaProperties struct.
    /// </summary>
    public class BattleArenaMono : MonoBehaviour
    {
        public bool AllowSpawning;
        // battle arena parameters
        public float2 FieldDimensions;
        // obstacle prefabs to spawn 
        public int NumberOfObstaclesToSpawn;
        // obstacle prefabs
        public GameObject ObstaclePrefab;
        // random values
        public uint RandomSeed;
        // troop prefabs
        public GameObject PlayerTroopPrefab;
        // number of prefabs to spawn in one go per job 
        public int NumberOfTroopsPerJob;
        [HideInInspector]
        public int EntitiesSpawnedCount;
        // Max entities allowed to spawn in total
        public int MaxEntitesCount;
    }
    /// <summary>
    /// Baker class to bake BattleArenaMono data into the Battle arena properties struct
    /// </summary>
    public class BattleArenaBaker : Baker<BattleArenaMono>
    {
        // function to bake data into BattleArenaMono class
        public override void Bake(BattleArenaMono authoring)
        {
            // Getting entity having the battleArenaProperties component
            var battleArenaEntity = GetEntity(TransformUsageFlags.Dynamic);
            // mapping battleArenaMono class properties to BattleArenaProperties struct
            AddComponent(battleArenaEntity, 
                    new BattleArenaProperties
                    {
                        AllowSpawning = authoring.AllowSpawning,
                        FieldDimensions = authoring.FieldDimensions,
                        NumberOfObstaclesToSpawn = authoring.NumberOfObstaclesToSpawn,
                        ObstaclePrefab = GetEntity(authoring.ObstaclePrefab, TransformUsageFlags.Dynamic),
                        PlayerTroopPrefab = GetEntity(authoring.PlayerTroopPrefab, TransformUsageFlags.Dynamic),
                        NumberOfTroopsPerJob = authoring.NumberOfTroopsPerJob,
                        EntitiesSpawnedCount = authoring.EntitiesSpawnedCount,
                        MaxEntitesCount = authoring.MaxEntitesCount
                    }
                );
            // maping battleArenaMono class random property to BattleArenaRandom struct
            AddComponent(battleArenaEntity, 
                    new BattleArenaRandom
                    {
                        Value = Random.CreateFromIndex(authoring.RandomSeed)
                    }    
                );
        }
    }
}