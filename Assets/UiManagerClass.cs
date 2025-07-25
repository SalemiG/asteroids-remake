using UnityEngine;
using UnityEngine.UI;

public class UiManagerClass : MonoBehaviour
{
    public Slider slider; // Assicurati di avere un componente Slider assegnato in Unity
    public void StartButton()
    {
        // Logica per avviare il gioco
        Debug.Log("Game Started");
        // Qui puoi aggiungere il codice per iniziare il gioco, come caricare una scena o resettare lo stato del gioco
    }

    private void Update()
    {
        // Aggiorna il valore dello slider in base a qualche logica, se necessario
        if (slider != null)
        {
            Debug.Log("Slider Value: " + slider.value);
        }
    }

}
