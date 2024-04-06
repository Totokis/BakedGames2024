using UnityEngine;

public class ShowersController : MonoBehaviour
{
    public static ShowersController Instance { get; private set; }

    private Shower[] showers;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Instance == null)
            Instance = this;
    }

    public void StartShowers()
    {
        foreach(var shower in showers)
        {
            shower.StartShower();
        }
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
