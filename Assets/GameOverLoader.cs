using System;
using UnityEngine;

public class GameOverLoader : MonoBehaviour
{
    private void OnEnable()
    {
        FindFirstObjectByType<ChangeSceneSimplifier>().ChangeSceneToScoreBoard();
    }
}
