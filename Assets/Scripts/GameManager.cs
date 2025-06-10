using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game Settings")]
    [Tooltip("Número máximo de balas que el jugador puede disparar.")]
    [SerializeField] private int maxAmmo = 10; 

    private int ammoLeft;
    private int score;

    public static int LastScore { get; set; }

    // Inicializa la instancia y la munición
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        ammoLeft = maxAmmo;
    }

    // Actualiza la UI al iniciar el juego
    private void Start()
    {
        UIManager.Instance.UpdateScore(score);
        UIManager.Instance.UpdateShots(ammoLeft);
    }

    // Lógica al disparar: reduce munición y verifica si termina el juego
    public void OnShotFired()
    {
        ammoLeft--;
        UIManager.Instance.UpdateShots(ammoLeft);

        if (ammoLeft <= 0)
            EndGame();
    }

    // Suma puntos al puntaje actual y actualiza la UI
    public void AddScore(int points)
    {
        score += points;
        UIManager.Instance.UpdateScore(score);
    }

    // Termina el juego y muestra la pantalla de Game Over
    private void EndGame()
    {
        LastScore = score;
        SceneManager.LoadScene("GameOver");
    }
}