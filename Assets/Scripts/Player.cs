using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Animator animator;
    [SerializeField] private Transform horizontal;

    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float maxHorizontalDistance;


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
}
