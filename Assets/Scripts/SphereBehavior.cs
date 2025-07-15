using UnityEngine;

public class SphereBehavior : MonoBehaviour
{
    [Header("Velocità")]
    [SerializeField] float speed = 10f;
    [SerializeField] float force = 10f;
    [SerializeField] bool isActive;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Rigidbody2D rb;
    //[SerializeField] Collider collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.position = new Vector3(speed, 0, 0) * Time.deltaTime + transform.position;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("A premuto");
        }

    }



   
}
