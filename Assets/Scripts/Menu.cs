using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    private UIDocument menu;

    // BOTONES
    private Button botonJugar;
    private Button botonAyuda;
    private Button botonCreditos;
    private Button botonSalir;

    private Button regresarTutorial;
    private Button regresarDatos;

    // PANELES
    private VisualElement entrada;
    private VisualElement tutorial;
    private VisualElement datos;

    void OnEnable()
    {
        menu = GetComponent<UIDocument>();
        var root = menu.rootVisualElement;

        // 🔹 BOTONES MENÚ
        botonJugar = root.Q<Button>("BotonJugar");
        botonAyuda = root.Q<Button>("BotonAyuda");
        botonCreditos = root.Q<Button>("BotonCreditos");
        botonSalir = root.Q<Button>("BotonSalir");

        // 🔹 BOTONES REGRESAR
        regresarTutorial = root.Q<Button>("RegresarTutorial");
        regresarDatos = root.Q<Button>("RegresarDatos");

        // 🔹 PANELES
        entrada = root.Q<VisualElement>("Entrada");
        tutorial = root.Q<VisualElement>("Tutorial");
        datos = root.Q<VisualElement>("Datos");

        // 🔹 ESTADO INICIAL
        entrada.style.display = DisplayStyle.Flex;
        tutorial.style.display = DisplayStyle.None;
        datos.style.display = DisplayStyle.None;

        // 🔥 CALLBACKS

        if (botonJugar != null)
            botonJugar.RegisterCallback<ClickEvent>(IrAJuego);

        if (botonAyuda != null)
            botonAyuda.RegisterCallback<ClickEvent>(AbrirAyuda);

        if (botonCreditos != null)
            botonCreditos.RegisterCallback<ClickEvent>(AbrirCreditos);

        if (botonSalir != null)
            botonSalir.RegisterCallback<ClickEvent>(SalirJuego);

        if (regresarTutorial != null)
            regresarTutorial.RegisterCallback<ClickEvent>(RegresarDesdeTutorial);

        if (regresarDatos != null)
            regresarDatos.RegisterCallback<ClickEvent>(RegresarDesdeDatos);
    }

    void OnDisable()
    {
        if (botonJugar != null)
            botonJugar.UnregisterCallback<ClickEvent>(IrAJuego);

        if (botonAyuda != null)
            botonAyuda.UnregisterCallback<ClickEvent>(AbrirAyuda);

        if (botonCreditos != null)
            botonCreditos.UnregisterCallback<ClickEvent>(AbrirCreditos);

        if (botonSalir != null)
            botonSalir.UnregisterCallback<ClickEvent>(SalirJuego);

        if (regresarTutorial != null)
            regresarTutorial.UnregisterCallback<ClickEvent>(RegresarDesdeTutorial);

        if (regresarDatos != null)
            regresarDatos.UnregisterCallback<ClickEvent>(RegresarDesdeDatos);
    }

    // 🎮 JUGAR
    void IrAJuego(ClickEvent evt)
    {
        Debug.Log("Ir a SampleScene");
        SceneManager.LoadScene("SampleScene");
    }

    // ❓ AYUDA
    void AbrirAyuda(ClickEvent evt)
    {
        entrada.style.display = DisplayStyle.None;
        tutorial.style.display = DisplayStyle.Flex;
        datos.style.display = DisplayStyle.None;
    }

    // ⭐ CREDITOS
    void AbrirCreditos(ClickEvent evt)
    {
        entrada.style.display = DisplayStyle.None;
        tutorial.style.display = DisplayStyle.None;
        datos.style.display = DisplayStyle.Flex;
    }

    // 🔙 REGRESAR DESDE TUTORIAL
    void RegresarDesdeTutorial(ClickEvent evt)
    {
        entrada.style.display = DisplayStyle.Flex;
        tutorial.style.display = DisplayStyle.None;
    }

    // 🔙 REGRESAR DESDE DATOS
    void RegresarDesdeDatos(ClickEvent evt)
    {
        entrada.style.display = DisplayStyle.Flex;
        datos.style.display = DisplayStyle.None;
    }

    // ❌ SALIR DEL JUEGO
    void SalirJuego(ClickEvent evt)
    {
        Debug.Log("Saliendo...");

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}