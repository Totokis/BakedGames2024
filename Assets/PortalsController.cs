using UnityEngine;

public class PortalsController : MonoBehaviour
{
    public static PortalsController instance;

    public Portal FirstPortal;
    public Portal SecondPortal;

    public void StartPortals(float offset)
    {

    }
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
