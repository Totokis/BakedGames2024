using System;
using System.Collections;
using UnityEngine;

public class Shower : MonoBehaviour
{

    public ParticleSystem particleSystem;

    internal void StartShower()
    {
        StartCoroutine(StartShowerCoroutine());
    }

    IEnumerator StartShowerCoroutine()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.3f, 1f));
        GetComponent<ShakeBehavior>().StartShake();
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.3f, 1f));
        particleSystem.Play();
    }

    internal void StopShower()
    {
        StartCoroutine(StopShowerCoroutine());
    }

    IEnumerator StopShowerCoroutine()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(0.1f, 1f));
        particleSystem.Stop();
    }
}
