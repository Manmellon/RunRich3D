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
        Debug.Log(deltaPos);

        horizontal.position = Vector3.Lerp(horizontal.position - horizontal.right * horizontalSpeed,
                     horizontal.position + horizontal.right * horizontalSpeed,
                     deltaPos);

        float clampedX = Mathf.Clamp(horizontal.localPosition.x, -maxHorizontalDistance, maxHorizontalDistance);
        horizontal.localPosition = new Vector3(clampedX, 0, 0);
    }
}
