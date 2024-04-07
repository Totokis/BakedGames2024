using UnityEngine;

public class ShowersController : MonoBehaviour
{
    public static ShowersController Instance { get; private set; }

    [SerializeField]
    private Shower[] showers;

    void Start()
    {
        if(Instance == null)
            Instance = this;
    }

    public void StartShowers(float offset)
    {
        print("Start showers ");

        foreach (var shower in showers)
        {
            shower.StartShower();
        }

        Invoke(nameof(StopShowers), offset);
    }

    public void StopShowers()
    {
        foreach (var shower in showers)
        {
            shower.StopShower();
        }
    }
}
