using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void MoveSide(float newPosition)
    {
        Debug.Log(newPosition);
    }
}
