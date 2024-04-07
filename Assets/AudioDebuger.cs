using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioDebuger : MonoBehaviour
{
    [SerializeField]
    private AudioClip testSound;

    [SerializeField]
    private AudioSource audioSource;

    

     private IEnumerator Start()
     {
         yield return new WaitForSeconds(3);

         audioSource.PlayOneShot(testSound);
     }
}
