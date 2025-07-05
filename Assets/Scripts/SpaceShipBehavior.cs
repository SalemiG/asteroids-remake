using UnityEngine;

public class SpaceShipBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float thrustForce = 5f;      // forza di spinta in avanti
    public float rotationSpeed = 180f;  // gradi al secondo
    public float maxSpeed = 5f;         // velocità massima

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
        ClampVelocity();
    }

    void HandleRotation()
    {
        float rotationInput = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            rotationInput = 1f;
        else if (Input.GetKey(KeyCode.RightArrow))
            rotationInput = -1f;

        transform.Rotate(Vector3.forward, rotationInput * rotationSpeed * Time.deltaTime);
    }

    void HandleThrust()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector2 force = transform.up * thrustForce;
            rb.AddForce(force);
        }
    }

    void ClampVelocity()
    {
        if (rb.linearVelocity.magnitude > maxSpeed) // Updated from 'velocity' to 'linearVelocity'
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed; // Updated from 'velocity' to 'linearVelocity'
        }
    }


}
