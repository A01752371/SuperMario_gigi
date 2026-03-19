using UnityEngine;
using UnityEngine.UIElements;

public class CreditosScroll : MonoBehaviour
{
    private VisualElement texto;

    private float posicionY;
    private float velocidad = 30f; // más rápido porque Update usa deltaTime
    private bool mover = true;

    void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // BUSCA EXACTAMENTE tu label
        texto = root.Q<VisualElement>("Valeria");

        if (texto != null)
        {
            // agarramos la posición REAL desde el UXML
            posicionY = texto.resolvedStyle.top;
        }
    }

    void Update()
    {
        if (texto == null || !mover) return;

        posicionY -= velocidad * Time.deltaTime;

        float altoTexto = texto.layout.height;

        // cuando se sale completamente del viewport, reinicia
        if (posicionY < -altoTexto)
        {
            posicionY = 300f; // ajusta si quieres que reaparezca más abajo
        }

        texto.style.top = posicionY;
    }
}