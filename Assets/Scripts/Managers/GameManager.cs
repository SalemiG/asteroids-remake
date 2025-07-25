    using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] AsteroidBehavior asteroidsPrefab;
    public AsteroidBehavior asteroid;
    public SpaceShipBehavior player;
    public static GameManager Instance;
    void Start()
    {
        asteroid = Instantiate(asteroidsPrefab, Vector3.zero, Quaternion.identity);
        asteroid.OnDeath += HandleAsteroidExplotion;
        player.OnDeath += HandlePlayerDeath;
    }

    private void Awake()
    {
        // Assicurati che ci sia solo un'istanza di GameManager
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Debug.Log("GameManager destroyed, unsubscribing from events.");
    }

    void SpawnAsteroid()
    {

        asteroid = Instantiate(asteroidsPrefab, Vector3.zero, Quaternion.identity);
        asteroid.OnDeath += HandleAsteroidExplotion; // Subscribe to the new asteroid's event
    }

    private void HandleAsteroidExplotion()
    {
        Debug.Log("Asteroid Exploded");
        asteroid.OnDeath -= HandleAsteroidExplotion;
        Destroy(asteroid.gameObject);
        SpawnAsteroid(); // Spawn a new asteroid after the current one is destroyed
    }

    private void HandlePlayerDeath()
    {
        Debug.Log("GameManager detected that enemy died!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload the current scene
    }
}
