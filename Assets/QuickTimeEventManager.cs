using System.Collections;
using UnityEngine;

public class QuickTimeEventManager : MonoBehaviour
{

    
    void Start()
    {
        StartCoroutine(StartQTELoop());
    }

    IEnumerator StartQTELoop()
    {
        float offset = UnityEngine.Random.Range(10, 16f);
        yield return new WaitForSeconds(offset);

        if (UnityEngine.Random.value > 0.5f)
            PortalsController.instance.StartPortals(offset);

        StartCoroutine(StartQTELoop()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
