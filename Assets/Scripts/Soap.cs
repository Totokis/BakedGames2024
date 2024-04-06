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
        else if(collision.gameObject.GetComponent<Portal>() != null)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
