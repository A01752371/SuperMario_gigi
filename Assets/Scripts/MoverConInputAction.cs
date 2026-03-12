using UnityEngine;
using UnityEngine.InputSystem;

public class MoverConInputAction : MonoBehaviour
{
    [SerializeField]
    private InputAction accionMover;

    [SerializeField]
    private InputAction accionSaltar;

    private float velocidadX = 7f;
    private float velocidadY = 7f;

    private Rigidbody2D rb;
    private Animator animator;

    private bool enSuelo = false;

    void Start()
    {
        accionMover.Enable();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        accionSaltar.Enable();
        accionSaltar.performed += saltar;
    }

    void OnDisable()
    {
        accionSaltar.Disable();
        accionSaltar.performed -= saltar;
    }

    public void saltar(InputAction.CallbackContext context)
    {
        if (enSuelo)
        {
            rb.linearVelocityY = velocidadY;
            enSuelo = false;
        }
    }

    void Update()
    {
        Vector2 movimiento = accionMover.ReadValue<Vector2>();

        rb.linearVelocityX = velocidadX * movimiento.x;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}