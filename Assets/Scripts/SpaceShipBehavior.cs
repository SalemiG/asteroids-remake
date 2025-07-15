using UnityEngine;

public class SpaceShipBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float thrustForce = 5f;      // forza di spinta in avanti
    public float rotationSpeed = 180f;  // gradi al secondo
    public float maxSpeed = 5f;         // velocità massima

    private Rigidbody2D rb;
    [SerializeField] GameObject engineAnimation;
    [SerializeField] GameObject rocket;
    [SerializeField] GameObject shootingPoint1;
    private float nextFireTime = 0f;
    private float fireRate = 0.2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
        ClampVelocity();
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void HandleRotation()
    {
        float rotationInput = 0f;

        if (Input.GetKey(KeyCode.A))
            rotationInput = 1f;
        else if (Input.GetKey(KeyCode.D))
            rotationInput = -1f;

        transform.Rotate(Vector3.forward, rotationInput * rotationSpeed * Time.deltaTime);
    }

    void HandleThrust()
    {
        if (Input.GetKey(KeyCode.W))
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

    void Shoot()
    {
            Instantiate(rocket, shootingPoint1.transform.position, shootingPoint1.transform.rotation);
        
    }

    


}
