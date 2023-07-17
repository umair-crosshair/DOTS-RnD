using ComponentsAndTags;
using Unity.Entities;
using Unity.Mathematics;
using UnityEditor.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AuthoringAndMono
{
    public class GraveyardMono : MonoBehaviour
    {
        public float2 FieldDimensions;
        public int NumberOfTombstonesToSpawn;
        public GameObject TombstonePrefab;
        public uint RandomSeed;
    }

    public class GraveyardBaker : Baker<GraveyardMono>
    {
        public override void Bake(GraveyardMono authoring)
        {
            AddComponent(new GraveyardProperties{
                        FieldDimensions = authoring.FieldDimensions,
                        NumberOfTombstonesToSpawn = authoring.NumberOfTombstonesToSpawn,
                        TombstonePrefab = GetEntity(authoring.TombstonePrefab)
                    }
            );
            AddComponent(new GraveyardRandom{
                    Value = Unity.Mathematics.Random.CreateFromIndex(authoring.RandomSeed)
                }
            );
        }
    }
}