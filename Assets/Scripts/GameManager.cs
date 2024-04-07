using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isWarningDisplayed = false;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}
