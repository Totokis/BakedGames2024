using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Boolean _isSlidingLeft = false;
    private Boolean _isSlidingRight = false;
    private Boolean _isMidSlide => _isSlidingLeft || _isSlidingRight;
    private Single _playerInput = 0;
    private Single _jumpTime = 0.5f;
    private Boolean canSlideLeft = true;
    private Boolean canSlideRight = true;

    [SerializeField] private Single _speed = 250;
    [SerializeField] private Single _slideSpeed = 400;

    private Rigidbody2D rb;
    private Collider2D collider;
    private Animator animator;
    private BoxCollider2D boxCollider;
    private StaminaController staminaController;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        staminaController = GetComponent<StaminaController>();
    }

    void Update()
    {
        _playerInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Math.Abs(_playerInput * _speed));

        if (Input.GetKeyDown(KeyCode.Space) && staminaController.CanUseSlide())
        {
            SwapSprite();
        }

        if (_playerInput > 0 && !_isSlidingRight)
        {
            GetComponent<SpriteRenderer>().flipX = false; // Original orientation (facing right)
        }
        else if (_playerInput < 0 && !_isSlidingLeft)
        {
            GetComponent<SpriteRenderer>().flipX = true; // Flip sprite (facing left)
        }
    }

    void SwapSprite()
    {
        if (!_isMidSlide)
        {
            if (_playerInput > 0 && canSlideRight)
            {
                //RotateSpriteLeft();
                boxCollider.offset = new Vector2(collider.offset.x, 0.06f);
                boxCollider.size = new Vector3(0.47f, 0.12f);
                _isSlidingLeft = true;
                animator.SetBool("IsSliding", true);
                staminaController.UseSlide();
            }
            else if (_playerInput < 0 && canSlideLeft)
            {
                //RotateSpriteRight();
                boxCollider.offset = new Vector2(collider.offset.x, 0.06f);
                boxCollider.size = new Vector3(0.47f, 0.12f);
                _isSlidingRight = true;
                animator.SetBool("IsSliding", true);
                staminaController.UseSlide();
            }
            //Invoke("ResetRotation", _jumpTime);  //doubluje sie przy œcianie
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
        boxCollider.offset = new Vector2(collider.offset.x, 0.1804221f);
        boxCollider.size = new Vector3(0.1163553f, 0.364229f);
        _isSlidingLeft = false;
        _isSlidingRight = false;
        animator.SetBool("IsSliding", false);
    }

    void FixedUpdate()
    {
        if (_isSlidingLeft)
        {
            rb.velocity = new Vector2(1 * _slideSpeed * Time.fixedDeltaTime, 0);
        }
        else if (_isSlidingRight)
        {
            rb.velocity = new Vector2(-1 * _slideSpeed * Time.fixedDeltaTime, 0);
        }
        else if((_playerInput == 1 && !_isSlidingRight) || (_playerInput == -1 && !_isSlidingLeft))
        {
            rb.velocity = new Vector2( _playerInput * _speed * Time.fixedDeltaTime, 0);
        }
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
