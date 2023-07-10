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
        public uint RandomSeed;
    }

    public class BattleArenabAKER : Baker<BattleArenaMono>
    {
        public override void Bake(BattleArenaMono authoring)
        {
            AddComponent(
                    new BattleArenaProperties
                    {
                        FieldDimensions = authoring.FieldDimensions,
                        NumberOfObstaclesToSpawn = authoring.NumberOfObstaclesToSpawn,
                        ObstaclePrefab = GetEntity(authoring.ObstaclePrefab)
                    }
                );
            AddComponent(
                    new BattleArenaRandom
                    {
                        Value = Random.CreateFromIndex(authoring.RandomSeed)
                    }    
                );
        }
    }
}