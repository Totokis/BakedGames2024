using System;
using UnityEngine;

public class Shower : MonoBehaviour
{

    public Animator animator;

    internal void StartShower()
    {
        GetComponent<ShakeBehavior>().StartShake();
        animator.StartPlayback();
    }

    internal void StopShower()
    {
        animator.StopPlayback();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
