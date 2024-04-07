using UnityEngine;

public class ShowersController : MonoBehaviour
{
    public static ShowersController Instance { get; private set; }

    [SerializeField]
    private Shower[] showers;

    public AudioSource AudioSource;
    public AudioClip ShowerClip;

    void Start()
    {
        if(Instance == null)
            Instance = this;
    }

    public void StartShowers(float offset)
    {
        print("Start showers ");

        AudioSource.PlayOneShot(ShowerClip);
        foreach (var shower in showers)
        {
            shower.StartShower();
        }

        Invoke(nameof(StopShowers), offset);
    }

    public void StopShowers()
    {
        AudioSource.Stop();
        foreach (var shower in showers)
        {
            shower.StopShower();
        }
    }
}
