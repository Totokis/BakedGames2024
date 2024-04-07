using UnityEngine;

public class ChangeSceneSimplifier : MonoBehaviour
{
    public void ChangeSceneToGame()
    {
        GetComponent<ChangeScene>().LoadOtherScene(SceneNames.GameSTR);
    }

    public void ChangeSceneToIntro()
    {
        GetComponent<ChangeScene>().LoadOtherScene(SceneNames.IntroSTR);
    }

    public void ChangeSceneToMenu()
    {
        GetComponent<ChangeScene>().LoadOtherScene(SceneNames.MainMenuSTR);
    }

    public void ChangeSceneToGameOver()
    {
        GetComponent<ChangeScene>().LoadOtherScene(SceneNames.GameOverSTR);
    }
}
