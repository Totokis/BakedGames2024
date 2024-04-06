using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Boolean _isMidJump = false;
    private Single _playerInput = 0;
    private Single _jumpTime = 0.5f;

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
        if(!_isMidJump)
        {
            _isMidJump = true;

            if (_playerInput >= 0)
            {
                RotateSpriteLeft();
            }
            else if (_playerInput < 0)
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isMidJump && collision.transform.CompareTag("Wall"))
        {
            ResetRotation();
            UnlockJump();
        }
    }
}
