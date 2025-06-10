using UnityEngine;
using UnityEngine.InputSystem;

public class MainMenu : MonoBehaviour
{
    // Inicia el juego cargando la escena principal
    public void OnStartButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    // Sale de la aplicación
    public void OnExitButton()
    {
        Application.Quit();
    }
}
