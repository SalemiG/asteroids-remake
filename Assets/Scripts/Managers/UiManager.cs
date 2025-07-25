using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    float horizontalInput;
    Vector2 mousePosition;
    private void Update()
    {
        


        if (EventSystem.current.currentSelectedGameObject != null)
            EventSystem.current.SetSelectedGameObject(null);
    }
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
        //Application.Quit();
   
        Debug.Log("Start button clicked");
        // Add logic to start the game or perform an action
    }
}
