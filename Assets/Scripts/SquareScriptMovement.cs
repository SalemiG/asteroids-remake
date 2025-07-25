using UnityEngine;

public class SquareScriptMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float horizontalInput;
    float verticalInput;
    [SerializeField] float speed = 5f; // Velocità di movimento del quadrato
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Muovi il quadrato in base all'input dell'utente
        transform.position += new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

    }
}
