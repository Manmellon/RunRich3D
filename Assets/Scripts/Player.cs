using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void MoveSide(float newPosition)
    {
        Debug.Log(newPosition);
    }
}
