using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool IsFirst = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(IsFirst && collision.GetComponent<Soap>() != null)
        {
            collision.transform.position = PortalsController.instance.SecondPortal.transform.position;
        }
    }
}
