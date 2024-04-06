using UnityEngine;

public class Soap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            EventManager.Instance.AddScore();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
