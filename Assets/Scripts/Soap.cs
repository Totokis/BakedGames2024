using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Soap : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioClip SoapPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Portal>() != null)
        {
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }

    private bool picked = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && !GameManager.Instance._isWarningDisplayed)
        {
            picked = true;
            EventManager.Instance.AddScore();
            AudioSource.PlayOneShot(SoapPickup);
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(GetComponent<Rigidbody2D>());

            LeanTween.scale(gameObject, Vector3.zero, 0.8f)
                .setEaseOutSine();

            //LeanTween.move(gameObject, FindObjectOfType<PlayerController>().pickupPoint, 0.69f)
            //    .setEaseOutSine();
            print("Pick");

            var pileDest = GameManager.Instance.DisplaySoapOnPile();
            if (pileDest != Vector3.zero)
            {
                // Define the start, control, and end points for the Bezier curve
                Vector3 startPosition = transform.position; // Starting at the current position
                Vector3 endPosition = pileDest; // Ending at the specified destination

                // Calculate a control point to create the boomerang effect
                // This is an imaginary point that the curve will pass through
                Vector3 controlPoint = (startPosition + endPosition) / 2 + Vector3.up * 5f; // Adjust the 5f value to control the height of the curve

                // Create a path using the start, control, and end points
                LTBezierPath boomerangPath = new LTBezierPath(new Vector3[] { startPosition, controlPoint, controlPoint, endPosition });

                // Use LeanTween to move the gameObject along the path
                LeanTween.move(gameObject, boomerangPath.pts, 0.69f)
                    .setEase(LeanTweenType.easeOutSine);
            }


            Invoke(nameof(GetRid), 1f);
        }
        else if (!picked && collision.transform.CompareTag("Floor"))
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Vector3 slipDirection = lastVelocity.normalized;
            slipDirection.y = 0;
            float soapSlipSpeed = UnityEngine.Random.Range(1f, 2.5f); // Consider setting a consistent speed instead of random
            GetComponent<Rigidbody2D>().velocity = slipDirection * soapSlipSpeed;
            
            Invoke("DisplayWarning", 2f);
        }
    }

    private Vector2 lastVelocity;
    private void Update()
    {
        // Keep updating the lastVelocity with the current velocity each frame
        if (GetComponent<Rigidbody2D>())
        {
            lastVelocity = GetComponent<Rigidbody2D>().velocity;
        }
    }

    private void GetRid()
    {
        Destroy(gameObject);
    }

    private void DisplayWarning()
    {
        if (picked || GameManager.Instance._isWarningDisplayed)
        {
            return;
        }

        transform.parent.Find("Warning").gameObject.SetActive(true);
        GameManager.Instance._isWarningDisplayed = true;
        Invoke("EndGame", 1f);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("GameOver");
    }
}
