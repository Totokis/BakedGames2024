using System;
using System.Collections;
using UnityEngine;

public class QuickTimeEventManager : MonoBehaviour
{
    Boolean _initial = true;
    void Start()
    {
        StartCoroutine(StartQTELoop());
    }

    IEnumerator StartQTELoop()
    {
        if(_initial)
            yield return new WaitForSeconds(6f);
        _initial = false;

        Single offset = UnityEngine.Random.Range(11, 16f);

        yield return new WaitForSeconds(UnityEngine.Random.Range(1.5f, 3));

        //if (UnityEngine.Random.value > 0.5f)
        //    PortalsController.instance.StartPortals(offset);
        //else
        ShowersController.Instance.StartShowers(offset);

        yield return new WaitForSeconds(offset);
        StartCoroutine(StartQTELoop()); 
    }
}
