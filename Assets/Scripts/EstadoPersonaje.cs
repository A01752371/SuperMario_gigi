using UnityEngine;

public class EstadoPersonaje : MonoBehaviour
{
    public bool estaeEnPiso { get; private set; } = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            estaeEnPiso = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            estaeEnPiso = false;
        }
    }
}