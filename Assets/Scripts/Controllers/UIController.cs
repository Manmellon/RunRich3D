using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject mainScreen;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TextMeshProUGUI levelNumberText;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button retryButton;

    private Core core;

    private void Start()
    {
        core = Core.Instance;

        core.levelManager.OnLevelStarted += () => UpdateLevel(core.levelManager.CurrentLevelIndex);

        //startButton.onClick.AddListener(() => { core.levelManager.StartLevel(); startButton.gameObject.SetActive(false); });
        retryButton.onClick.AddListener(() =>
        {
            core.levelManager.RestartLevel();
            gameOverScreen.SetActive(false);
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
}
