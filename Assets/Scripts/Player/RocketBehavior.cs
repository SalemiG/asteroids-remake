using UnityEngine;

public class RocketBehavior : MonoBehaviour
{

    public float speed = 10f;         // velocità del proiettile
    public float lifeTime = 5f;       // durata massima in secondi
    private Rigidbody2D rb;
    public SphereBehavior sfera;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Imposta la velocità nella direzione in cui il proiettile "guarda"
        rb.linearVelocity = transform.up * speed;

        // Distruggi il proiettile dopo un certo tempo
        Destroy(gameObject, lifeTime);

         //float value = sfera.horizontalInput;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Proiettile ha colpito {collision.gameObject.name}");

        // Qui puoi aggiungere effetti, danni, ecc.

        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Proiettile ha colpito {collision.gameObject.name}");

        if(collision.gameObject.CompareTag("Asteroid"))
        {
            
        }

        Destroy(gameObject);
    }
}
