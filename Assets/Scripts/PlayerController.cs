using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Horizontal player keyboard input
    //  -1 = Left
    //   0 = No input
    //   1 = Right
    private float playerInput = 0;

    // Horizontal player speed
    [SerializeField] private float speed = 250;

    private Rigidbody2D rb;

    // Initialises this component
    // (NB: Is called automatically before the first frame update)
    void Start()
    {
        // Get component references
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Detect and store horizontal player input   
        playerInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwapSprite();
        }
    }

    // Swap the player sprite scale to face the movement direction
    void SwapSprite()
    {
        // Right or no input
        if (playerInput >= 0)
        {
            RotateSpriteLeft();
            Invoke("RotateSpriteRight", 1f);
        }
        // Left
        else if (playerInput < 0)
        {
            RotateSpriteRight();
            Invoke("RotateSpriteLeft", 1f);
        }
    }

    private void RotateSpriteRight()
    {
        this.transform.Rotate(0, 0, 90);
    }

    private void RotateSpriteLeft()
    {
        this.transform.Rotate(0, 0, -90);
    }

    // Is called automatically every physics step
    void FixedUpdate()
    {
        // Move the player horizontally
        rb.velocity = new Vector2(
            playerInput * speed * Time.fixedDeltaTime,
            0
        );
    }
}
