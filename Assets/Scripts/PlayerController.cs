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


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            Invoke("ResetRotation", _jumpTime);
            Invoke("UnlockJump", _jumpTime);
        }
    }

    private void RotateSpriteRight()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
    }

    private void RotateSpriteLeft()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
    }

    private void ResetRotation()
    {
        this.transform.rotation = Quaternion.identity;
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
        }
    }
}
