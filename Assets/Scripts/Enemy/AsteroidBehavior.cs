using UnityEngine;
using System;
public class AsteroidBehavior : MonoBehaviour
{
   [SerializeField] float speed = 5f;
    Vector2 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Evento pubblico
    public event Action OnDeath;


    private void OnEnable()
    {
        // Iscrivi l'evento OnDeath all'evento PlayAsteroidExploded
        EventManager.OnAsteroidExploded += Explode;
    }
    private void OnDisable()
    {
        EventManager.OnAsteroidExploded -= Explode;
    }
    void Start()
    {
        speed = UnityEngine.Random.Range(1f, 5f);
        direction = UnityEngine.Random.insideUnitCircle.normalized; // Get a random direction in 2D space
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit Wall");
        Explode();
        if (collision.CompareTag("Player"))
        {
            // Handle collision with player
            Debug.Log("Asteroid hit the player!");
            collision.GetComponent<SpaceShipBehavior>().GameOver(); // Assuming SpaceShipBehavior has an Explode method
            // You can add more logic here, like damaging the player or destroying the asteroid
        }
        
    }

    public void Explode()
    {
        // Chiama l'evento, se qualcuno è iscritto
        //OnDeath?.Invoke();
        EventManager.PlayAsteroidExploded();
        Destroy(gameObject);
    }
}
