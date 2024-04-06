using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool IsFirst = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsFirst && collision.GetComponent<Soap>() != null)
        {
            collision.transform.position = PortalsController.instance.SecondPortal.transform.position;
            collision.transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            Vector2 horizontalDirection = UnityEngine.Random.value > 0.5f ? Vector2.right : Vector2.left;
            collision.GetComponent<Rigidbody2D>()?.AddForce(horizontalDirection * UnityEngine.Random.Range(11f, 20f));

        }
    }
}
