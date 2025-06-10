using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI References")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text shotsText;

    // Inicializa la instancia singleton del UIManager
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Actualiza el texto de la puntuación en la interfaz
    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = $"Puntuación: {score}";
    }

    // Actualiza el texto de los disparos restantes en la interfaz
    public void UpdateShots(int shotsLeft)
    {
        if (shotsText != null)
            shotsText.text = $"Balas: {shotsLeft}";
    }
}
