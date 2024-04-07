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

    private bool picked = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && !GameManager.Instance._isWarningDisplayed)
        {
            picked = true;
            EventManager.Instance.AddScore();
            AudioSource.PlayOneShot(SoapPickup);
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());

            LeanTween.scale(gameObject, Vector3.zero, 0.5f)
                .setEaseOutSine();

            print("Pick");

            Invoke(nameof(GetRid), 1f);
        }
        else if (!picked && collision.transform.CompareTag("Floor"))
        {
            print("Floor");
            Invoke("DisplayWarning", 2f);
        }
    }

    private void GetRid()
    {
        Destroy(gameObject);
    }

    private void DisplayWarning()
    {
        if (picked || GameManager.Instance._isWarningDisplayed)
        {
            return;
        }
        print("Warning");

        transform.parent.Find("Warning").gameObject.SetActive(true);
        GameManager.Instance._isWarningDisplayed = true;
        Invoke("EndGame", 1f);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
