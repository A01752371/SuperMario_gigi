using UnityEngine;

public class GoombaPatrulla : MonoBehaviour
{
    public float velocidad = 2f;
    private int direccion = -1;

    private Rigidbody2D rb;
    private bool puedeCambiar = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento constante
        rb.linearVelocity = new Vector2(direccion * velocidad, rb.linearVelocity.y);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //  1. Si toca a Mario → desaparece y NO cambia dirección
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            return; //  evita que entre a la lógica de dirección
        }

        //  2. Cambiar dirección SOLO si es choque lateral
        foreach (ContactPoint2D contacto in collision.contacts)
        {
            if (Mathf.Abs(contacto.normal.x) > 0.5f && puedeCambiar)
            {
                direccion *= -1;
                puedeCambiar = false;

                // evita que cambie varias veces seguidas
                Invoke("ResetCambio", 0.2f);
                break;
            }
        }
    }

    void ResetCambio()
    {
        puedeCambiar = true;
    }
}