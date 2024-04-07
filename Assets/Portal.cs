using System;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Boolean IsFirst = false;

    public SpriteRenderer Renderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsFirst && collision.GetComponent<Soap>() != null)
        {
            collision.transform.position = PortalsController.instance.SecondPortal.transform.position;
            collision.transform.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

            LeanTween.scale(collision.gameObject, Vector3.zero, 0.2f)
                .setLoopPingPong(1);

            Vector2 horizontalDirection = UnityEngine.Random.value > 0.5f ? Vector2.right : Vector2.left;
            collision.GetComponent<Rigidbody2D>()?.AddForce(horizontalDirection * UnityEngine.Random.Range(11f, 20f));

        }
    }

    public void HidePortal()
    {
        Renderer.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }

    public void ShowPortal()
    {
        Renderer.enabled = true;
        GetComponent<BoxCollider2D>().enabled = true;  
    }
}
