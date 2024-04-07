using System;
using System.Collections;
using UnityEngine;

public class QuickTimeEventManager : MonoBehaviour
{
    Boolean _initial = true;
    void Start()
    {
        //PJ: StartCoroutine(StartQTELoop());
    }

    IEnumerator StartQTELoop()
    {
        if(_initial)
            yield return new WaitForSeconds(6f);
        _initial = false;

        Single offset = UnityEngine.Random.Range(10, 16f);

        yield return new WaitForSeconds(offset * UnityEngine.Random.value);

        //if (UnityEngine.Random.value > 0.5f)
        //    PortalsController.instance.StartPortals(offset);
        //else
        ShowersController.Instance.StartShowers(offset);

        yield return new WaitForSeconds(offset);
        StartCoroutine(StartQTELoop()); 
    }
}
