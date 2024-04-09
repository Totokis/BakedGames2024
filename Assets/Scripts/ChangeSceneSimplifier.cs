using UnityEngine;

public class ChangeSceneSimplifier : MonoBehaviour
{
    public void ChangeSceneToGame()
    {
        if (GameManager.Instance != null) {
        
            GameManager.Instance.DestroyThyself();
        }
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

    public void ChangeSceneToScoreBoard()
    {
        GetComponent<ChangeScene>().LoadOtherScene(SceneNames.ScoreBoard);
    }

    public void ChangeSceneToTutorial()
    {
        GetComponent<ChangeScene>().LoadOtherScene(SceneNames.TutorialSTR);
    }

    public void ChangeToOutroScene()
    {
        GetComponent<ChangeScene>().LoadOtherScene(SceneNames.OutroScene);
    }
}
