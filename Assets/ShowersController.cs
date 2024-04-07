using UnityEngine;

public class ShowersController : MonoBehaviour
{
    public static ShowersController Instance { get; private set; }

    [SerializeField]
    private Shower[] showers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
