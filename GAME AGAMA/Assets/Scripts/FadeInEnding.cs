using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInEnding : MonoBehaviour
{
    public float fadeDuration = 2f; // Duration for the fade-in
    private SpriteRenderer spriteRenderer;
    private Color spriteColor;

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Initialize the sprite's color with alpha set to 0 (fully transparent)
        spriteColor = spriteRenderer.color;
        spriteColor.a = 0f;
        spriteRenderer.color = spriteColor;

        // Start the fade-in coroutine
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the new alpha value
            float newAlpha = Mathf.Clamp01(elapsedTime / fadeDuration);

            // Apply the new alpha to the sprite's color
            spriteColor.a = newAlpha;
            spriteRenderer.color = spriteColor;

            // Wait for the next frame
            yield return null;
        }

        // Ensure the sprite is fully visible at the end
        spriteColor.a = 1f;
        spriteRenderer.color = spriteColor;
    }
}
