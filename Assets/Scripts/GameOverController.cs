using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    [SerializeField] private Text finalScoreText;

    // Muestra la puntuación final al iniciar la pantalla de Game Over
    private void Start()
    {
        finalScoreText.text = "Puntuación final: " + GameManager.LastScore;
    }

    // Reinicia el juego cargando la escena principal
    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }

    // Regresa al menú principal
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
