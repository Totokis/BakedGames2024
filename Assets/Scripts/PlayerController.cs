using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 MovementSpeed = new Vector2(10.0f, 10.0f);
    private new Rigidbody2D rigidbody2D;
    private Vector2 inputVector = new Vector2(0.0f, 0.0f);

    void Awake()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        inputVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    void FixedUpdate()
    {
        rigidbody2D.MovePosition(rigidbody2D.position + (inputVector * MovementSpeed * Time.fixedDeltaTime));
    }
}
