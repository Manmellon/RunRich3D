using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Player player;

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private bool isSwiping = false;
    public float swipeThreshold = 50f;
    //public float moveSpeed = 5f;

    float swipeDirection;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.touchCount == 0) return;

        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
                startTouchPosition = touch.position;
                isSwiping = true;
                break;

            case TouchPhase.Moved:
                if (isSwiping)
                {
                    Vector2 swipeDelta = touch.position - startTouchPosition;

                    float currentSwipeDirection = Mathf.Sign(swipeDelta.x);
                    if (currentSwipeDirection != swipeDirection)
                    {
                        swipeDirection = currentSwipeDirection;
                        startTouchPosition = currentTouchPosition;
                    }

                    currentTouchPosition = touch.position;
                    
                    swipeDelta = currentTouchPosition - startTouchPosition;

                    if (Mathf.Abs(swipeDelta.x) > swipeThreshold)
                    {
                        float deltaPos = Mathf.InverseLerp(-1, 1, swipeDelta.x / Screen.width);
                        player.MoveSide(deltaPos);
                    }
                }
                break;

            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                isSwiping = false;
                break;
        }
    }
}
