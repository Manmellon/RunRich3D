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
    
    [Header("Settings")]
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float maxHorizontalDistance;
    [SerializeField] private RichLimit[] richLimits;

    [Header("Stats")]
    [SerializeField] private int money;

    void Start()
    {
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
        money = Mathf.Max(0, money + addingMoney);

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
        for (int i = 0; i < richLimits.Length; i++)
        {
            richLimits[i].model.SetActive(i == index);
        }
    }
}
