using ButchersGames;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct RichLimit
{
    public int limit;
    public GameObject model;
    public Color stageSliderColor;
    public string name;
}

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Transform horizontal;
    [SerializeField] private CharacterController characterController;
    [SerializeField] private GameObject model;
    [SerializeField] private Slider richSlider;
    [SerializeField] private Image sliderFillImage;
    [SerializeField] private TextMeshProUGUI stageNameText;
    
    [Header("Settings")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float maxHorizontalDistance;
    [SerializeField] private RichLimit[] richLimits;


    [Header("Stats")]
    [SerializeField] private int money;

    private int currentModelIndex;

    public float characterRadius => characterController.radius;
    public float ForwardSpeed => forwardSpeed;

    private bool isPlaying;
    private Core core;

    private void Awake()
    {
        core = Core.Instance;
        core.levelManager.OnLevelSelected += () => SpawnPlayer();
        core.levelManager.OnLevelStarted += () => StartWalking();
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (!isPlaying) return;

        transform.position += transform.forward * forwardSpeed * Time.deltaTime;
    }

    void SpawnPlayer()
    {
        Level level = core.levelManager.GetComponentInChildren<Level>();
        transform.position = level.spawnPos;
        transform.rotation = level.spawnRotate;

        money = 40;
        SwapModel(1, true);
        UpdateRichSlider(currentModelIndex);

        animator.SetTrigger("Reset");
    }

    void StartWalking()
    {
        isPlaying = true;
        animator.ResetTrigger("Reset");
        animator.ResetTrigger("Loose");
        animator.ResetTrigger("Win");
        animator.SetTrigger("Start");
    }

    public void MoveSide(float deltaPos)
    {
        //Debug.Log(deltaPos);

        float minX = Mathf.Max(-maxHorizontalDistance, 
                               horizontal.localPosition.x - horizontalSpeed);

        float maxX = Mathf.Min(maxHorizontalDistance,
                               horizontal.localPosition.x + horizontalSpeed);

        float x = Mathf.Lerp(minX, maxX, deltaPos);
        horizontal.localPosition = new Vector3(x, 0, 0);
    }

    public void AddMoney(int addingMoney)
    {
        money = Mathf.Clamp(money + addingMoney, 0, richLimits[richLimits.Length - 1].limit);

        animator.SetFloat("Rich", (float) money / richLimits[richLimits.Length - 1].limit);

        AudioClip clip = addingMoney > 0 ? core.soundController.GetCoin : core.soundController.LostMoney;
        core.soundController.PlaySound(audioSource, clip);

        int i;
        for (i = richLimits.Length - 1; i >= 0; i--)
        {
            if (money >= richLimits[i].limit)
            {
                break;
            }
        }

        SwapModel(i);

        UpdateRichSlider(i);

        if (money <= 0)
        {
            isPlaying = false;
            animator.SetTrigger("Loose");
            core.UIController.ShowGameOver();
        }

    }

    void SwapModel(int index, bool firstSet = false)
    {
        if (index == currentModelIndex) return;

        richLimits[currentModelIndex].model.SetActive(false);
        richLimits[index].model.SetActive(true);

        if (index > currentModelIndex && !firstSet)
        {
            animator.SetTrigger("Upgrade");

            Vector3 rot = model.transform.localRotation.eulerAngles;
            rot.y += 360;
            model.transform.DOLocalRotate(rot, 0.75f, RotateMode.FastBeyond360);

        }

        currentModelIndex = index;
    }

    void UpdateRichSlider(int index)
    {
        richSlider.value = money;
        richSlider.maxValue = richLimits[richLimits.Length - 1].limit;

        stageNameText.text = richLimits[index].name;
        stageNameText.color = sliderFillImage.color = richLimits[index].stageSliderColor;

        core.UIController.UpdateMoney(money);
    }

    public void StepSound()
    {
        core.soundController.PlayStepSound(audioSource, currentModelIndex >= 2);
    }
}
