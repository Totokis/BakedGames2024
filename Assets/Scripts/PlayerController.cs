using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Boolean _isMidJump = false;
    private Single _playerInput = 0;
    private Single _jumpTime = 0.5f;
    private bool canSlideLeft = true;
    private bool canSlideRight = true;

    [SerializeField] private Single _speed = 250;

    private Rigidbody2D rb;
    private Collider2D collider;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    void Update()
    {
        _playerInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwapSprite();
        }
    }

    void SwapSprite()
    {
        if (!_isMidJump)
        {
            _isMidJump = true;

            if (_playerInput > 0 && canSlideRight)
            {
                RotateSpriteLeft();
            }
            else if (_playerInput < 0 && canSlideLeft)
            {
                RotateSpriteRight();
            }
            Invoke("ResetRotation", _jumpTime); //doubluje sie przy œcianie
            Invoke("UnlockJump", _jumpTime);
        }
    }

    private void RotateSpriteRight()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (collider.bounds.size.x / 2), transform.position.z);
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));

    }

    private void RotateSpriteLeft()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (collider.bounds.size.x / 2), transform.position.z);
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));

    }

    private void ResetRotation()
    {
        if (this.transform.rotation != Quaternion.identity)
        {
            this.transform.rotation = Quaternion.identity;
            transform.position = new Vector3(transform.position.x, transform.position.y - (collider.bounds.size.y / 2), transform.position.z);
        }
    }

    private void UnlockJump()
    {
        _isMidJump = false;
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(
            _playerInput * _speed * Time.fixedDeltaTime,
            0
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            if (collision.gameObject.name == "Wall Left")
            {
                canSlideLeft = false;
            }
            else if (collision.gameObject.name == "Wall Right")
            {
                canSlideRight = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            if (collision.gameObject.name == "Wall Left")
            {
                canSlideLeft = true;
            }
            else if (collision.gameObject.name == "Wall Right")
            {
                canSlideRight = true;
            }
        }
    }
}
