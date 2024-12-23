using ButchersGames;
using UnityEngine;

public class Core : MonoBehaviour
{
    public EffectsController effectsController;
    public LevelManager levelManager;
    public SoundController soundController;
    public UIController UIController;

    public static Core Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
