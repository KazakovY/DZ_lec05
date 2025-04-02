using UnityEngine;

public class GroundProjectileLauncher : MonoBehaviour
{
    public float launchSpeed = 10f;
    public float angle = 45f;
    private bool isGrounded = true;
    private Rigidbody rb;
    private bool hasLaunched = false; // Флаг запуска

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !hasLaunched)
        {
            Launch();
            hasLaunched = true; // Запрещаем повторный запуск
        }
    }

    void Launch()
    {
        float angleRad = angle * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(
            Mathf.Cos(angleRad),
            Mathf.Sin(angleRad),
            0
        );
        rb.linearVelocity = direction * launchSpeed;
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}