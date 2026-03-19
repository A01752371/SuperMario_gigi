using UnityEngine;
using UnityEngine.UIElements;

public class CreditosScroll : MonoBehaviour
{
    public float speed = 40f;

    private Label valeria;
    private float y = 0f;
    private float alturaMitad = 0f;
    private bool listo = false;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        valeria = root.Q<Label>("Valeria");

        if (valeria == null)
        {
            Debug.LogError("No se encontró Valeria");
            return;
        }

        // Esperar a que el layout tenga tamaño real
        valeria.RegisterCallback<GeometryChangedEvent>(evt =>
        {
            // Altura total del texto renderizado
            float h = valeria.resolvedStyle.height;

            // Como duplicaste el contenido, usamos la mitad
            alturaMitad = h / 2f;

            // Asegura que empezamos desde arriba
            y = 0f;
            listo = true;
        });
    }

    void Update()
    {
        if (!listo) return;

        y -= speed * Time.deltaTime;

        // 👇 ESTO mueve el contenido dentro del label (no el label)
        valeria.style.top = y;

        // 🔁 loop infinito sin corte (por duplicación)
        if (y <= -alturaMitad)
        {
            y = 0f;
        }
    }
}