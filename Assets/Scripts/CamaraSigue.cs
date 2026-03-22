using UnityEngine;

public class CamaraSigue : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    [SerializeField] private float suavizado = 0.125f;
    [SerializeField] private Vector3 desfase = new Vector3(0, 0, -10);
    [SerializeField] private float limiteIzquierdo = 0f;
    [SerializeField] private float limiteDerecho = 18f;

    // Guardamos la altura inicial para que no cambie nunca
    private float alturaFija;

    void Start()
    {
        alturaFija = transform.position.y;
    }

    void LateUpdate()
    {
        if (objetivo != null && objetivo.gameObject.activeSelf)
        {
            float xLimitada = Mathf.Clamp(objetivo.position.x, limiteIzquierdo, limiteDerecho);
            
            // Usamos alturaFija en lugar de transform.position.y
            Vector3 posicionDeseada = new Vector3(xLimitada, alturaFija + desfase.y, desfase.z);
            
            transform.position = Vector3.Lerp(transform.position, posicionDeseada, suavizado);
        }
    }
}