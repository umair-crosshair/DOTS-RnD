using ComponentsAndTags;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace AuthoringAndMono
{
    public class BattleArenaMono : MonoBehaviour
    {
        public float2 FieldDimensions;
        public int NumberOfObstaclesToSpawn;
        public GameObject ObstaclePrefab;
        public GameObject ObstaclePrefab2;
        public GameObject ObstaclePrefab3;
        public uint RandomSeed;
    }

    public class BattleArenaBaker : Baker<BattleArenaMono>
    {
        public override void Bake(BattleArenaMono authoring)
        {
            var graveyardEntity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(graveyardEntity, 
                    new BattleArenaProperties
                    {
                        FieldDimensions = authoring.FieldDimensions,
                        NumberOfObstaclesToSpawn = authoring.NumberOfObstaclesToSpawn,
                        ObstaclePrefab = GetEntity(authoring.ObstaclePrefab, TransformUsageFlags.Dynamic),
                        ObstaclePrefab2 = GetEntity(authoring.ObstaclePrefab2, TransformUsageFlags.Dynamic),
                        ObstaclePrefab3 = GetEntity(authoring.ObstaclePrefab3, TransformUsageFlags.Dynamic)
                    }
                );
            AddComponent(graveyardEntity, 
                    new BattleArenaRandom
                    {
                        Value = Random.CreateFromIndex(authoring.RandomSeed)
                    }    
                );
        }
    }
}