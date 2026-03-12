using System;
using UnityEngine;

public class CambiaAnimacion : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private EstadoPersonaje estado;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        estado = GetComponentInChildren<EstadoPersonaje>();
    }

    void Update()
    {
        animator.SetFloat("velocidad", MathF.Abs(rb.linearVelocityX));

        sr.flipX = rb.linearVelocityX < 0;

        animator.SetBool("enPiso", rb.linearVelocityY == 0);;
    }
}