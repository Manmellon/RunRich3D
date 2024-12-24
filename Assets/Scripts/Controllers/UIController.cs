using ButchersGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private TextMeshProUGUI levelNumberText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button continueButton;

    private Core core;

    private void Awake()
    {
        core = Core.Instance;

        core.levelManager.OnLevelSelected += () => UpdateLevel(LevelManager.CurrentLevel);

    }
    private void Start()
    {
        
        //startButton.onClick.AddListener(() => { core.levelManager.StartLevel(); startButton.gameObject.SetActive(false); });
        retryButton.onClick.AddListener(() =>
        {
            core.levelManager.RestartLevel();
            gameOverScreen.SetActive(false);
            mainScreen.SetActive(true);
            startButton.gameObject.SetActive(true);
        });

        continueButton.onClick.AddListener(() =>
        {
            core.levelManager.NextLevel();
            winScreen.SetActive(false);
            mainScreen.SetActive(true);
            startButton.gameObject.SetActive(true);
        });
    }

    public void StartButtonEvent()
    {
        core.levelManager.StartLevel();
        startButton.gameObject.SetActive(false);
    }

    public void UpdateLevel(int lvl)
    {
        levelNumberText.text = "Уровень " + lvl.ToString();
    }

    public void UpdateMoney(int money)
    {
        moneyText.text = money.ToString();
    }

    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
        mainScreen.SetActive(false);
    }

    public void ShowWinScreen()
    {
        winScreen.SetActive(true);
        mainScreen.SetActive(false);
    }
}
