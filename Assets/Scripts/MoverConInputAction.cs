using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoverConInputAction : MonoBehaviour
{
    [SerializeField]
    private InputAction accionMover;//en las 4 direcciones

    [SerializeField]
    private InputAction accionSaltar;

    private float velocidadX = 7f;
    private float velocidadY = 7f;

    private Rigidbody2D rb;

    // NUEVO: verificar si está en el suelo
    private bool enSuelo = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Habilitar InputAction
        accionMover.Enable();
        rb = GetComponent<Rigidbody2D>();
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
        // Solo saltar si está en el suelo
        if (enSuelo)
        {
            rb.linearVelocityY = velocidadY;
            enSuelo = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        //Leer la entrada
        Vector2 movimiento = accionMover.ReadValue<Vector2>();

        rb.linearVelocityX = velocidadX * movimiento.x;
    }


    // NUEVO: detectar cuando toca el suelo
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}