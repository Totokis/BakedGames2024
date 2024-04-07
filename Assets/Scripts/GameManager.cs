using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Boolean _isWarningDisplayed = false;

    public ScoreManager scoreManager;

    public Transform soapPile;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void DisplaySoapOnPile()
    {
        soapPile.GetChild(scoreManager.Score - 1).GetComponent<SpriteRenderer>().enabled = true;
    }
}
