using UnityEngine;

public class ShakeBehavior : MonoBehaviour
{
    // The duration of the shake effect
    public float shakeDuration = 0.5f;

    // The intensity of the shake (how far it moves)
    public float shakeIntensity = 1f;

    // Original position of the object to return to after shaking
    private Vector3 originalPosition;

    void Start()
    {
        // Save the original position of the object
        originalPosition = transform.localPosition;
    }

    // Call this method to start shaking
    public void StartShake()
    {
        // Cancel all tweens on this object to avoid conflicts
        LeanTween.cancel(gameObject);

        // Move the object to its original position before starting the shake
        transform.localPosition = originalPosition;

        // Start the shake effect on X axis
        LeanTween.moveLocalX(gameObject, originalPosition.x + Random.Range(-shakeIntensity, shakeIntensity), shakeDuration / 10).setLoopPingPong(10);

        // Start the shake effect on Y axis
        LeanTween.moveLocalY(gameObject, originalPosition.y + Random.Range(-shakeIntensity, shakeIntensity), shakeDuration / 10).setLoopPingPong(10).setOnComplete(ResetPosition);
    }

    // Reset the position of the object after shaking
    void ResetPosition()
    {
        LeanTween.moveLocal(gameObject, originalPosition, 0.1f);
    }
}
