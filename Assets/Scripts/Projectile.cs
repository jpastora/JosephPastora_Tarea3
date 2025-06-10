using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Lifetime")]
    [SerializeField] private float lifeTime = 5f;

    // Destruye el proyectil después de un tiempo determinado
    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Detecta colisiones con objetivos y aplica el efecto correspondiente
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Target"))
        {
            if (other.TryGetComponent<Target>(out var target))
            {
                target.Hit();
            }
            Destroy(gameObject);
        }
    }
}
