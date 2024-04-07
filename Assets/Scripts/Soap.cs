using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Soap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Portal>() != null)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && !GameManager.Instance.isWarningDisplayed)
        {
            EventManager.Instance.AddScore();
            Destroy(gameObject);
        }
        else if (collision.transform.CompareTag("Floor"))
        {
            Invoke("DisplayWarning", 2f);
        }
    }

    private void DisplayWarning()
    {
        if (GameManager.Instance.isWarningDisplayed)
        {
            return;
        }

        transform.parent.Find("Warning").gameObject.SetActive(true);
        GameManager.Instance.isWarningDisplayed = true;
        Invoke("EndGame", 1f);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
