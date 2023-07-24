using TMPro;
using UnityEngine;

namespace AuthoringAndMono
{
    
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// Mono behaviour to reference UI screens 
    /// </summary>
    [Header("Start simulation screen")]
    public GameObject StartSimulationScreen;
    public TMP_InputField EntitiesPerJob;
    public TMP_InputField EntitiesSpawnCount;
    
    public static UIManager Instance;
    // Setting singleton in the awake method 
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
}
