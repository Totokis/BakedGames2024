using System.Collections;
using UnityEngine;

public class QuickTimeEventManager : MonoBehaviour
{

    
    void Start()
    {
        StartCoroutine(StartQTELoop());
    }

    bool initial = true;
    IEnumerator StartQTELoop()
    {
        if(initial)
            yield return new WaitForSeconds(6f);
        initial = false;

        float offset = UnityEngine.Random.Range(10, 16f);

        if (UnityEngine.Random.value > 0.5f)
            PortalsController.instance.StartPortals(offset);
        else ShowersController.Instance.StartShowers(offset);

        yield return new WaitForSeconds(offset);
        StartCoroutine(StartQTELoop()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
