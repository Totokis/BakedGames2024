using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//add this bibliothek for the working with scenes
using UnityEngine.SceneManagement;
using System;

public class ChangeScene : MonoBehaviour
{
    public Image blackScreen;
    public GameObject mainObjectToTurnOn;
    public float fadingTime = 0.3f;

    public void LoadOtherScene(String sceneName)
    {
        Time.timeScale = 1;
        FadeIn();
        StartCoroutine("LoadSceneAfterTime", sceneName);
    }

    void Start()
    {
        FadeOut();
    }

    void FadeIn()
    {
        mainObjectToTurnOn.SetActive(true);
        blackScreen.canvasRenderer.SetAlpha(0);
        blackScreen.CrossFadeAlpha(1, fadingTime, false);
    }

    void FadeOut()
    {
        mainObjectToTurnOn.SetActive(true);
        blackScreen.canvasRenderer.SetAlpha(1);
        blackScreen.CrossFadeAlpha(0, fadingTime, false);
        StartCoroutine("DisactiveBlackscreenAfterTime", fadingTime);
    }

    IEnumerator LoadSceneAfterTime(String sceneNameToLoad)
    {
        yield return new WaitForSeconds(fadingTime);
        SceneManager.LoadScene(sceneNameToLoad);
        yield return null;
    }
    IEnumerable DisactiveBlackscreenAfterTime()
    {
        yield return new WaitForSeconds(fadingTime);
        mainObjectToTurnOn.SetActive(false);
        yield return null;
    }

}