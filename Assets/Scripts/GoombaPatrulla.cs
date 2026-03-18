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
        rb.linearVelocity = new Vector2(direccion * velocidad, rb.linearVelocity.y);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        foreach (ContactPoint2D contacto in collision.contacts)
        {
            //  SOLO colisión lateral
            if (Mathf.Abs(contacto.normal.x) > 0.5f && puedeCambiar)
            {
                direccion *= -1;
                puedeCambiar = false;
                Invoke("ResetCambio", 0.2f);
                break;
            }
        }

        //  Si toca a Mario
        if (collision.gameObject.CompareTag("Player"))
        {
            SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.enabled = false;
            }
        }
    }

    void ResetCambio()
    {
        puedeCambiar = true;
    }
}