using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject targetPrefab;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnX = 10f;
    [SerializeField] private float minY = -4f;
    [SerializeField] private float maxY = 4f;

    // Inicia la invocación repetida para generar objetivos
    private void Start()
    {
        if (targetPrefab != null)
        {
            InvokeRepeating(nameof(Spawn), 1f, spawnInterval);
        }
        else
        {
            Debug.LogWarning("TargetSpawner: targetPrefab is not assigned.", this);
        }
    }

    // Genera un objetivo en una posición aleatoria dentro del rango especificado
    private void Spawn()
    {
        float y = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(spawnX, y, 0f);
        Instantiate(targetPrefab, spawnPos, Quaternion.identity);
    }
}
