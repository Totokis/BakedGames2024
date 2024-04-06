using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Boolean _isMidJump = false;
    private Single _playerInput = 0;
    private Single _jumpTime = 0.5f;
    // Horizontal player speed
    [SerializeField] private Single _speed = 250;

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
        _playerInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwapSprite();
        }
    }

    // Swap the player sprite scale to face the movement direction
    void SwapSprite()
    {
        if(!_isMidJump)
        {
            _isMidJump = true;

            // Right or no input
            if (_playerInput >= 0)
            {
                RotateSpriteLeft();
                Invoke("RotateSpriteRight", _jumpTime);
                Invoke("UnlockJump", _jumpTime);
            }
            // Left
            else if (_playerInput < 0)
            {
                RotateSpriteRight();
                Invoke("RotateSpriteLeft", _jumpTime);
                Invoke("UnlockJump", _jumpTime);
            }
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

    private void UnlockJump()
    {
        _isMidJump = false;
    }

    // Is called automatically every physics step
    void FixedUpdate()
    {
        // Move the player horizontally
        rb.velocity = new Vector2(
            _playerInput * _speed * Time.fixedDeltaTime,
            0
        );
    }
}
