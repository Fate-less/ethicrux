using UnityEngine;
using TMPro;

public class SwipeCase : MonoBehaviour
{
    public float swipeThreshold = 1f; // Distance needed to consider a swipe (adjust for world space)
    public string agreeCase; // Text for upward swipe
    public string denyCase; // Text for downward swipe
    public Transform resetPos;
    public Animator phoneAnim;
    public float maxTiltUp = -20f; // Maximum tilt on the z-axis when swiping up
    public float maxTiltDown = 43f; // Maximum tilt on the z-axis when swiping down


    private Vector3 startTouchPosition;
    private bool isDragging = false;
    private Transform cardTransform; // Reference to the card's Transform
    private TextMeshPro caseText; // Reference to the TextMeshPro component for displaying text
    private CaseHandler caseHandler;
    private CaseStats caseStats;

    private void Start()
    {
        cardTransform = transform; // Use the Transform of the GameObject
        caseText = GameObject.Find("TestCaseTMP").GetComponent<TextMeshPro>();
        resetPos = GameObject.Find("CrimeCaseTransform").GetComponent<Transform>();
        phoneAnim = GameObject.Find("PhoneScreen").GetComponent<Animator>();
        caseHandler = GameObject.Find("CaseHandler").GetComponent<CaseHandler>();
        caseStats = GetComponent<CaseStats>();
        caseText.text = caseStats.testCase;
    }
    public float minYPosition = -0.7395f;
    public float maxYPosition = 3f;
    void Update()
    {
        // Change the animation to "Yes" or "No" based on direction
        phoneAnim.SetFloat("Parameter", transform.position.y - resetPos.position.y);
        if(transform.position.y - resetPos.position.y > 1)
        {
            StatModifier.instance.ChangeStatCheck(caseStats.declineTrust, caseStats.declineConscience, caseStats.declineEconomy, caseStats.declinePolitic);
        }
        else if(transform.position.y - resetPos.position.y < -1.5f)
        {
            StatModifier.instance.ChangeStatCheck(caseStats.agreeTrust, caseStats.agreeConscience, caseStats.agreeEconomy, caseStats.agreePolitic);
        }
        else
        {
            StatModifier.instance.ChangeStatCheck(0,0,0,0);
        }


        if (Input.GetMouseButtonDown(0)) // Detect touch start
        {
            startTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startTouchPosition.z = 0; // Keep on the same plane
            isDragging = true;
        }
        
        if (Input.GetMouseButton(0) && isDragging) // Detect dragging
        {
            Vector3 currentTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentTouchPosition.z = 0; // Keep on the same plane
            Vector3 delta = currentTouchPosition - startTouchPosition;

            // Calculate the new Y position
            float newYPosition = cardTransform.position.y + delta.y;

            // Restrict movement to the y-axis only and clamp the position.y
            float clampedY = Mathf.Clamp(newYPosition, minYPosition, maxYPosition); // Define minYPosition and maxYPosition
            cardTransform.position = new Vector3(cardTransform.position.x, clampedY, cardTransform.position.z);

            // Adjust rotation based on vertical drag
            float tiltZ = Mathf.Lerp(
                0,
                transform.position.y > resetPos.position.y ? maxTiltUp : maxTiltDown,
                Mathf.Abs(transform.position.y - resetPos.position.y) / 1
            );
            tiltZ = Mathf.Clamp(tiltZ, maxTiltUp, maxTiltDown);
            cardTransform.rotation = Quaternion.Euler(0, 0, tiltZ);

            // Update start position for smooth dragging
            startTouchPosition = currentTouchPosition;
        }

        if (Input.GetMouseButtonUp(0) && isDragging) // Detect touch end
        {
            isDragging = false;
            Vector3 endTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            endTouchPosition.z = 0; // Keep on the same plane
            Vector3 swipeDelta = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(transform.position.y - resetPos.position.y) > swipeThreshold)
            {
                Debug.Log("Should have counted here!");
                // Trigger actions based on swipe direction
                if (transform.position.y - resetPos.position.y > 0)
                {
                    SwipeUp();
                }
                else
                {
                    SwipeDown();
                }
            }
            else
            {
                ResetCard();
            }
        }
    }

    private void SwipeUp()
    {
        Debug.Log("Swiped Up - YES");

        Invoke("DelayDestroy",1.1f);
        // AudioManager.instance.PlaySFX("Cheer");
        AudioManager.instance.PlaySFX("Gasp");

        // Add your logic for swiping up (e.g., call a method)
        StatModifier.instance.ChangeStat(caseStats.declineTrust, caseStats.declineConscience, caseStats.declineEconomy, caseStats.declinePolitic);
    }

    private void SwipeDown()
    {
        Debug.Log("Swiped Down - NO");

        Invoke("DelayDestroy",1.1f);
        AudioManager.instance.PlaySFX("Hammer");
        // Add your logic for swiping down (e.g., call a method)
        StatModifier.instance.ChangeStat(caseStats.agreeTrust, caseStats.agreeConscience, caseStats.agreeEconomy, caseStats.agreePolitic);
    }

    void DelayDestroy()
    {
        SpawnCase();
        Destroy(gameObject);
    }
    private void ResetCard()
    {
        Debug.Log("Resetting Card..");
        // Reset position (adjust to your original card position)
        cardTransform.position = resetPos.position;

        // Reset rotation
        cardTransform.rotation = resetPos.rotation;
    }

    private void SpawnCase()
    {
        caseHandler.SpawnCase();
    }
}
