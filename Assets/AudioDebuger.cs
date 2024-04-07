using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class AudioDebuger : MonoBehaviour
{
    [SerializeField]
    private AudioClip heartBit ;

    [SerializeField]
    private AudioClip endVoice;
    

    [SerializeField]
    private AudioSource audioSource;

    public void PlayHeartBit()
    {
        if(Application.platform == RuntimePlatform.WebGLPlayer) 
            audioSource.PlayOneShot(heartBit);    
        
    }

    public void StopHeartBit()
    {
        if(Application.platform == RuntimePlatform.WebGLPlayer)
            audioSource.Stop();
    }
    
    public void PlayEndVoice()
    {
        if(Application.platform == RuntimePlatform.WebGLPlayer)
            audioSource.PlayOneShot(endVoice);
    }

    public void StopEndVoice()
    {
        if(Application.platform == RuntimePlatform.WebGLPlayer)
            audioSource.Stop();
    }
    
}
