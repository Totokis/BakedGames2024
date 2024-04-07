using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        this.GetComponent<ChangeScene>().LoadOtherScene(SceneNames.IntroSTR);
    }
}
