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
}
