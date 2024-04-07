using System;
using UnityEngine;

public class ShakeBehavior : MonoBehaviour
{
    public Single shakeDuration = 0.5f;
    public Single shakeIntensity = 1f;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void StartShake()
    {
        LeanTween.cancel(gameObject);
        transform.localPosition = originalPosition;

        // Start the shake effect on X axis
        LeanTween.moveLocalX(gameObject, originalPosition.x + UnityEngine.Random.Range(-shakeIntensity, shakeIntensity), shakeDuration / 10).setLoopPingPong(10);

        // Start the shake effect on Y axis
        LeanTween.moveLocalY(gameObject, originalPosition.y + UnityEngine.Random.Range(-shakeIntensity, shakeIntensity), shakeDuration / 10).setLoopPingPong(10).setOnComplete(ResetPosition);
    }

    void ResetPosition()
    {
        LeanTween.moveLocal(gameObject, originalPosition, 0.1f);
    }
}
