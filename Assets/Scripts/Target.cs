using UnityEngine;

public class Target : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 2f;

    [Header("Scoring")]
    [SerializeField] private int scoreValue = 10;

    [Header("Lifetime Settings")]
    [SerializeField] private float leftBoundary = -10f;
    [SerializeField] private float rightBoundary = 10f;

    // Actualiza la posición y verifica los límites en cada frame
    void Update()
    {
        Move();
        CheckBounds();
    }

    // Mueve el objetivo hacia la derecha
    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    // Destruye el objetivo si sale de los límites definidos
    private void CheckBounds()
    {
        float x = transform.position.x;
        if (x < leftBoundary || x > rightBoundary)
        {
            Destroy(gameObject);
        }
    }

    // Suma puntos y destruye el objetivo cuando es alcanzado
    public void Hit()
    {
        GameManager.Instance.AddScore(scoreValue);
        Destroy(gameObject);
    }

    // Detecta colisiones con proyectiles y aplica el efecto correspondiente
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(other.gameObject);
            Hit();
        }
    }
}
