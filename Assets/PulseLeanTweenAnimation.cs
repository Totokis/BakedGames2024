using UnityEngine;

public class PulseLeanTweenAnimation : MonoBehaviour
{
    public float minScale = 0.8f;    // Minimum scale of the object
    public float maxScale = 1.2f;    // Maximum scale of the object
    public float speed = 1.0f;       // Speed of the scale animation

    void Start()
    {
        Pulse();
    }

    void Pulse()
    {
        LeanTween.scale(gameObject, Vector3.one * maxScale, speed)
            .setEase(LeanTweenType.easeInOutSine)
            .setLoopPingPong()
            .setOnComplete(() => 
            {
                LeanTween.scale(gameObject, Vector3.one * minScale, speed)
                    .setEase(LeanTweenType.easeInOutSine)
                    .setLoopPingPong();
            });
    }

}
