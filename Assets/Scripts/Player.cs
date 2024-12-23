using UnityEngine;

[System.Serializable]
public struct RichLimit
{
    public int limit;
    public GameObject model;
}

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private Transform horizontal;
    [SerializeField] private CharacterController characterController;
    
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
    void Start()
    {
        currentModelIndex = 1;
    }

    void Update()
    {
        transform.position += transform.forward * forwardSpeed * Time.deltaTime;
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

        int i;
        for (i = richLimits.Length - 1; i >= 0; i--)
        {
            if (money >= richLimits[i].limit)
            {
                break;
            }
        }

        SwapModel(i);

        if (money <= 0)
        {
            //GameOver();
        }

    }

    void SwapModel(int index)
    {
        if (index == currentModelIndex) return;

        richLimits[currentModelIndex].model.SetActive(true);
        richLimits[index].model.SetActive(true);

        //TODO: Animation of happy rotation
        animator.SetTrigger("Upgrade");

        currentModelIndex = index;
    }
}
