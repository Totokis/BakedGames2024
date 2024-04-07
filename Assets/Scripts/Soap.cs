using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Soap : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip SoapPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Portal>() != null)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && !GameManager.Instance._isWarningDisplayed)
        {
            EventManager.Instance.AddScore();
            AudioSource.PlayOneShot(SoapPickup);
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());

            LeanTween.scale(gameObject, Vector3.zero, 0.5f)
                .setEaseOutSine();


            Invoke(nameof(GetRid), 2f);
        }
        else if (collision.transform.CompareTag("Floor"))
        {
            Invoke("DisplayWarning", 2f);
        }
    }

    private void GetRid()
    {
        Destroy(gameObject);
    }

    private void DisplayWarning()
    {
        if (GameManager.Instance._isWarningDisplayed)
        {
            return;
        }

        transform.parent.Find("Warning").gameObject.SetActive(true);
        GameManager.Instance._isWarningDisplayed = true;
        Invoke("EndGame", 1f);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
