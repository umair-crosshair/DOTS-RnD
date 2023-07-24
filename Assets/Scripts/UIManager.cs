using System;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Start simulation screen")]
    public GameObject StartSimulationScreen;
    public TMP_InputField EntitiesPerJob;
    public TMP_InputField EntitiesSpawnCount;
    
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}