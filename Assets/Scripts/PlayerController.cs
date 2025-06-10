using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform gunPivot;
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private GameObject projectilePrefab;

    [Header("Cursor")]
    [SerializeField] private Texture2D crosshairTexture;
    [SerializeField] private Vector2 crosshairHotspot = new Vector2(16, 16);

    [Header("Shooting Settings")]
    [SerializeField] private float fireRate = 2f;
    [SerializeField] private float projectileSpeed = 12f;

    private Camera mainCam;
    private Vector3 aimPoint;
    private float nextFireTime;

    // Inicializa la referencia a la cámara principal
    private void Awake()
    {
        mainCam = Camera.main;
    }

    // Configura el cursor personalizado al iniciar la escena
    private void Start()
    {
        if (crosshairTexture != null)
        {
            Cursor.SetCursor(crosshairTexture, crosshairHotspot, CursorMode.Auto);
            Cursor.visible = true;
        }
    }

    // Actualiza el punto de mira, rota el personaje y gestiona los disparos en cada frame
    private void Update()
    {
        UpdateAimPoint();
        RotateCharacter();
        HandleShooting();
    }

    // Actualiza la posición del punto de mira según la posición del mouse
    private void UpdateAimPoint()
    {
        Vector2 screenPos = Mouse.current.position.ReadValue();
        Vector3 screenPos3 = new Vector3(screenPos.x, screenPos.y, -mainCam.transform.position.z);
        aimPoint = mainCam.ScreenToWorldPoint(screenPos3);
    }

    // Rota el personaje para que apunte hacia el punto de mira
    private void RotateCharacter()
    {
        Vector2 dir = (Vector2)aimPoint - (Vector2)transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    // Gestiona la lógica de disparo verificando el tiempo y la entrada del mouse
    private void HandleShooting()
    {
        if (Mouse.current.leftButton.isPressed && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    // Instancia el proyectil y le aplica dirección y velocidad
    private void Shoot()
    {
        if (projectilePrefab == null || muzzlePoint == null) return;

        var proj = Instantiate(projectilePrefab, muzzlePoint.position, Quaternion.identity);
        Vector2 shootDir = ((Vector2)aimPoint - (Vector2)muzzlePoint.position).normalized;

        if (proj.TryGetComponent<Rigidbody2D>(out var rb))
            rb.linearVelocity = shootDir * projectileSpeed;

        float projAngle = Mathf.Atan2(shootDir.y, shootDir.x) * Mathf.Rad2Deg;
        proj.transform.rotation = Quaternion.Euler(0f, 0f, projAngle);

        GameManager.Instance.OnShotFired();
    }
}
