using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwipeCard : MonoBehaviour
{
    public float swipeThreshold = 100f; // Distance needed to consider a swipe
    public float tiltAngle = 15f; // Angle to tilt the card while dragging
    [TextArea] public string testCase;
    public string agreeCase;
    public string denyCase;

    private Vector2 startTouchPosition;
    private bool isDragging = false;
    private RectTransform cardTransform; // Reference to the card's RectTransform
    private TextMeshProUGUI caseText; // Reference to the Text showing the case

    private void Start()
    {
        cardTransform = gameObject.GetComponent<RectTransform>();
        caseText = GameObject.Find("testCaseTMP").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect touch start
        {
            startTouchPosition = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButton(0) && isDragging) // Detect dragging
        {
            Vector2 currentTouchPosition = Input.mousePosition;
            Vector2 delta = currentTouchPosition - startTouchPosition;

            // Tilt the card based on drag direction
            cardTransform.anchoredPosition = delta;
            cardTransform.rotation = Quaternion.Euler(0, 0, -delta.x / swipeThreshold * tiltAngle);

            // Change the text to "Yes" or "No" based on direction
            caseText.text = delta.x > 0 ? agreeCase : denyCase;
        }

        if (Input.GetMouseButtonUp(0) && isDragging) // Detect touch end
        {
            isDragging = false;
            Vector2 endTouchPosition = Input.mousePosition;
            Vector2 swipeDelta = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(swipeDelta.x) > swipeThreshold)
            {
                // Trigger actions based on swipe direction
                if (swipeDelta.x > 0)
                {
                    SwipeRight();
                }
                else
                {
                    SwipeLeft();
                }
            }

            // Reset card position and rotation
            ResetCard();
        }
        if (!isDragging)
        {
            caseText.text = testCase;
        }
    }

    private void SwipeLeft()
    {
        Debug.Log("Swiped Left - NO");
        // Add your logic for swiping left (e.g., call a method)
    }

    private void SwipeRight()
    {
        Debug.Log("Swiped Right - YES");
        // Add your logic for swiping right (e.g., call a method)
    }

    private void ResetCard()
    {
        cardTransform.anchoredPosition = Vector2.zero;
        cardTransform.rotation = Quaternion.identity;
        caseText.text = ""; // Reset text if needed
    }
}
