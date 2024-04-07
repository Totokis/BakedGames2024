using UnityEngine;

public class PortalsController : MonoBehaviour
{
    const float FIRST_PORTAL_Y = -2.505f;
    const float SECOND_PORTAL_Y = 3.3252f;

    public static PortalsController instance;

    public Portal FirstPortal;
    public Portal SecondPortal;

    public void StartPortals(float offset)
    {
        print("Start portals");
        FirstPortal.transform.position = new Vector3(UnityEngine.Random.Range(-5, 5f), FIRST_PORTAL_Y);
        SecondPortal.transform.position = new Vector3(UnityEngine.Random.Range(-5, 5f), SECOND_PORTAL_Y);

        FirstPortal.ShowPortal();
        SecondPortal.ShowPortal();

        Invoke(nameof(StopPortals), offset);
    }

    public void StopPortals()
    {
        FirstPortal.HidePortal();
        SecondPortal.HidePortal();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(instance == null)
            instance = this;

        StopPortals();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
