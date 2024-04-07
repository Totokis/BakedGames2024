using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ChangeScene : MonoBehaviour
{
    public Image BlackScreen;
    public GameObject MainObjectToTurnOn;
    public Single FadingTime = 0.3f;
    public Boolean ShouldFadeOutAtTheStart = true;
    public void LoadOtherScene(String sceneName)
    {
        Time.timeScale = 1;
        FadeIn();
        StartCoroutine("LoadSceneAfterTime", sceneName);
    }

    void Start()
    {
        if(ShouldFadeOutAtTheStart)
        {
            FadeOut();
        }
    }

    void FadeIn()
    {
        MainObjectToTurnOn.SetActive(true);
        BlackScreen.canvasRenderer.SetAlpha(0);
        BlackScreen.CrossFadeAlpha(1, FadingTime, false);
    }

    void FadeOut()
    {
        MainObjectToTurnOn.SetActive(true);
        BlackScreen.canvasRenderer.SetAlpha(1);
        BlackScreen.CrossFadeAlpha(0, FadingTime, false);
        StartCoroutine("DisactiveBlackscreenAfterTime", FadingTime);
    }

    IEnumerator LoadSceneAfterTime(String sceneNameToLoad)
    {
        yield return new WaitForSeconds(FadingTime);
        SceneManager.LoadScene(sceneNameToLoad);
        yield return null;
    }
    IEnumerable DisactiveBlackscreenAfterTime()
    {
        yield return new WaitForSeconds(FadingTime);
        MainObjectToTurnOn.SetActive(false);
        yield return null;
    }

}