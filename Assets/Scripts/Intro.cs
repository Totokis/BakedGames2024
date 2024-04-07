using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public void StartGame()
    {
        this.GetComponent<ChangeScene>().LoadOtherScene(SceneNames.GameSTR);
    }
}
