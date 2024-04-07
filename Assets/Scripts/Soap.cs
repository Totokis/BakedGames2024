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
        //print(collision.gameObject.tag);
        if (collision.transform.CompareTag("Player"))
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
        transform.parent.Find("Warning").gameObject.SetActive(true);
        Invoke("EndGame", 1f);
    }

    private void EndGame()
    {
        
        SceneManager.LoadScene("GameOver");
    }
}
