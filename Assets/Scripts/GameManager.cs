using System;
using System.Collections;
using System.Linq.Expressions;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Boolean _isWarningDisplayed = false;

    public ScoreManager scoreManager;

    public Transform soapPile;

    public int Score = 0;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        Score = 0;
        _isWarningDisplayed = false;
        DontDestroyOnLoad(this.gameObject);
    }

    public Vector3 DisplaySoapOnPile()
    {
        if (soapPile.childCount >= scoreManager.Score)
        {
            GameObject soap = soapPile.GetChild(scoreManager.Score - 1).gameObject;
            StartCoroutine(ShowOnPile(soap));
            return soap.transform.position;
        }
        return Vector3.zero;
    }

    public void DestroyThyself()
    {
        Destroy(gameObject);
        Instance = null;    // because destroy doesn't happen until end of frame
    }


    private IEnumerator ShowOnPile(GameObject soap)
    {
        yield return new WaitForSeconds(0.69f);
        soap.GetComponent<SpriteRenderer>().enabled = true;

    }
}
