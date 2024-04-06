using UnityEngine;
using UnityEngine.SceneManagement;

public class Soap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            EventManager.Instance.AddScore();
            Destroy(gameObject);
        }
        else if(collision.gameObject.GetComponent<Portal>() != null)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        else
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
}
