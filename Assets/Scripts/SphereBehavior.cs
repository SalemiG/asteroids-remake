using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereBehavior : MonoBehaviour
{
    [Header("Velocità")]
    [SerializeField] float speed = 10f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    int score = 0;
    //[SerializeField] Collider collider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] float horizontalInput;
    float verticalInput;

    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //transform.position = new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime + transform.position;
        transform.Translate(new Vector3(horizontalInput, verticalInput,0)   * speed * Time.deltaTime);


        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Ho Preso una Monetina");
        score++;
        scoreText.text = "Score: " + score.ToString();
        if (score >= 6)
        {
            winText.text = "You Win!";
            winText.gameObject.SetActive(true);
            //Time.timeScale = 0f; // Ferma il gioco
        }
        Destroy(collision.gameObject);
    }




}
