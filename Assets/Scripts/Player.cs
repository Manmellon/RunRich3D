using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveSide(float newPosition)
    {
        Debug.Log(newPosition);
    }
}
