using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    Player player;

    private Vector2 startTouchPosition;
    private Vector2 currentTouchPosition;
    private bool isSwiping = false;
    public float swipeThreshold = 50f;
    //public float moveSpeed = 5f;

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
                    currentTouchPosition = touch.position;
                    Vector2 swipeDelta = currentTouchPosition - startTouchPosition;

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
